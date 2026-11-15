
using UnityEngine;
using UnityEngine.UI;

public class BrightnessManager : MonoBehaviour
{
    private static BrightnessManager instance;
    private Image brightnessOverlay;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        float savedBrightness = PlayerPrefs.GetFloat("Brightness", 0.5f);
        float savedVolume = PlayerPrefs.GetFloat("Volume", 0.5f);

        AudioListener.volume = savedVolume;

        CreateOverlay();
        SetBrightness(savedBrightness);
    }

    private void CreateOverlay()
    {
        GameObject canvasObject = new GameObject("BrightnessCanvas");
        canvasObject.transform.SetParent(transform);

        Canvas canvas = canvasObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 999;

        canvasObject.AddComponent<CanvasScaler>();

        GameObject overlay = new GameObject("BrightnessOverlay");
        overlay.transform.SetParent(canvasObject.transform, false);

        brightnessOverlay = overlay.AddComponent<Image>();
        brightnessOverlay.color = new Color(0, 0, 0, 0);
        brightnessOverlay.raycastTarget = false;

        RectTransform rect = overlay.GetComponent<RectTransform>();
        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.one;
        rect.offsetMin = Vector2.zero;
        rect.offsetMax = Vector2.zero;
    }

    public static void SetBrightness(float value)
    {
        if (instance == null || instance.brightnessOverlay == null)
            return;

        value = Mathf.Clamp01(value);

        if (value < 0.5f)
        {
            float normalized = (0.5f - value) / 0.5f;
            float alpha = Mathf.Pow(normalized, 0.7f) * 0.75f;

            instance.brightnessOverlay.color =
                new Color(0, 0, 0, alpha);
        }
        else
        {
            float normalized = (value - 0.5f) / 0.5f;
            float alpha = Mathf.Pow(normalized, 2f) * 0.025f;

            instance.brightnessOverlay.color =
                new Color(1, 1, 1, alpha);
        }
    }
}
