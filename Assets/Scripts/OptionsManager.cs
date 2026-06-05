using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        // Wczytaj zapisaną głośność - domyślnie 1 (max)
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);
        volumeSlider.value = savedVolume;
        AudioListener.volume = savedVolume;

        // Nasłuchuj zmian suwaka
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    void OnVolumeChanged(float value)
    {
        // Zmień głośność w grze
        AudioListener.volume = value;

        // Zapisz ustawienie
        PlayerPrefs.SetFloat("Volume", value);
        PlayerPrefs.Save();
    }
}