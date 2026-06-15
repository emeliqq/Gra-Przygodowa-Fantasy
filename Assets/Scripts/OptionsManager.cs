using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider mouseSensitivitySlider;

    void Start()
    {
        // Głośność
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);
        volumeSlider.value = savedVolume;
        AudioListener.volume = savedVolume;
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);

        // Czułość myszy
        float savedSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 1f);
        mouseSensitivitySlider.value = savedSensitivity;
        mouseSensitivitySlider.onValueChanged.AddListener(OnSensitivityChanged);
    }

    void OnVolumeChanged(float value)
    {
        AudioListener.volume = value;

        PlayerPrefs.SetFloat("Volume", value);
        PlayerPrefs.Save();
    }

    void OnSensitivityChanged(float value)
    {
        PlayerPrefs.SetFloat("MouseSensitivity", value);
        PlayerPrefs.Save();
    }
}