
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider brightnessSlider;

    private void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("Volume", 0.5f);
        float savedBrightness = PlayerPrefs.GetFloat("Brightness", 0.5f);

        if (volumeSlider != null)
        {
            volumeSlider.SetValueWithoutNotify(savedVolume);
            volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        }

        AudioListener.volume = savedVolume;

        if (brightnessSlider != null)
        {
            brightnessSlider.SetValueWithoutNotify(savedBrightness);
            brightnessSlider.onValueChanged.AddListener(OnBrightnessChanged);
        }

        BrightnessManager.SetBrightness(savedBrightness);
    }

    private void OnDestroy()
    {
        if (volumeSlider != null)
            volumeSlider.onValueChanged.RemoveListener(OnVolumeChanged);

        if (brightnessSlider != null)
            brightnessSlider.onValueChanged.RemoveListener(OnBrightnessChanged);
    }

    private void OnVolumeChanged(float value)
    {
        AudioListener.volume = value;

        PlayerPrefs.SetFloat("Volume", value);
        PlayerPrefs.Save();
    }

    private void OnBrightnessChanged(float value)
    {
        BrightnessManager.SetBrightness(value);

        PlayerPrefs.SetFloat("Brightness", value);
        PlayerPrefs.Save();
    }
}
