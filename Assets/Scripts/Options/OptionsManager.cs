
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider brightnessSlider;
    public Button saveSettingsButton;
    public Button restoreDefaultsButton;

    private const float DefaultValue = 0.5f;

    private bool changesSaved = true;

    private void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("Volume", DefaultValue);
        float savedBrightness = PlayerPrefs.GetFloat("Brightness", DefaultValue);

        if (volumeSlider != null)
        {
            volumeSlider.SetValueWithoutNotify(savedVolume);
            volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        }

        if (brightnessSlider != null)
        {
            brightnessSlider.SetValueWithoutNotify(savedBrightness);
            brightnessSlider.onValueChanged.AddListener(OnBrightnessChanged);
        }

        if (saveSettingsButton != null)
            saveSettingsButton.onClick.AddListener(SaveSettings);

        if (restoreDefaultsButton != null)
            restoreDefaultsButton.onClick.AddListener(RestoreDefaults);

        AudioListener.volume = savedVolume;
        BrightnessManager.SetBrightness(savedBrightness);
    }

    private void OnDestroy()
    {
        if (!changesSaved)
            RestoreSavedSettings();

        if (volumeSlider != null)
            volumeSlider.onValueChanged.RemoveListener(OnVolumeChanged);

        if (brightnessSlider != null)
            brightnessSlider.onValueChanged.RemoveListener(OnBrightnessChanged);

        if (saveSettingsButton != null)
            saveSettingsButton.onClick.RemoveListener(SaveSettings);

        if (restoreDefaultsButton != null)
            restoreDefaultsButton.onClick.RemoveListener(RestoreDefaults);
    }

    private void OnVolumeChanged(float value)
    {
        AudioListener.volume = value;
        changesSaved = false;
    }

    private void OnBrightnessChanged(float value)
    {
        BrightnessManager.SetBrightness(value);
        changesSaved = false;
    }

    private void SaveSettings()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        PlayerPrefs.SetFloat("Brightness", brightnessSlider.value);
        PlayerPrefs.Save();

        changesSaved = true;
    }

    private void RestoreDefaults()
    {
        volumeSlider.SetValueWithoutNotify(DefaultValue);
        brightnessSlider.SetValueWithoutNotify(DefaultValue);

        AudioListener.volume = DefaultValue;
        BrightnessManager.SetBrightness(DefaultValue);

        SaveSettings();
    }

    private void RestoreSavedSettings()
    {
        float savedVolume = PlayerPrefs.GetFloat("Volume", DefaultValue);
        float savedBrightness = PlayerPrefs.GetFloat("Brightness", DefaultValue);

        AudioListener.volume = savedVolume;
        BrightnessManager.SetBrightness(savedBrightness);
    }
}
