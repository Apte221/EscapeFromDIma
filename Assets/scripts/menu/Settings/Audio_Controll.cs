using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;
    private const string VolumeKey = "GameVolume";

    void Start()
    {
        // Завантаження збереженої гучності або встановлення стандартного значення
        float savedVolume = PlayerPrefs.GetFloat(VolumeKey, 1f);
        AudioListener.volume = savedVolume;
        volumeSlider.value = savedVolume;

        // Додаємо слухача подій для зміни гучності
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat(VolumeKey, volume);
        PlayerPrefs.Save();
    }
}
