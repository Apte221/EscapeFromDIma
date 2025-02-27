using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;



public class VolumeControl : MonoBehaviour
{   
    public Slider slider;
    private const string VolumeKey = "GameVolume";
    public AudioMixer mixer;
    public string group;
    void Start()
    {

        // Завантаження збереженої гучності або встановлення стандартного значення
        float savedVolume = PlayerPrefs.GetFloat(VolumeKey, 1f);
        slider.value = savedVolume;
        float mappedVolume = savedVolume - 50f;
        mixer.SetFloat("volume",mappedVolume);
        

        // Додаємо слухача подій для зміни гучності
        slider.onValueChanged.AddListener(SetVolume);
        slider.onValueChanged.AddListener(setmixer);
    }
// Для збереження в файлах
    public void SetVolume(float volume)
    {
        
        PlayerPrefs.SetFloat(VolumeKey, volume);
        PlayerPrefs.Save();
        
    }
    // Для міксера , щоб норм звук був
    public void setmixer(float volume_mixer){

        volume_mixer -= 50;
        mixer.SetFloat("volume",volume_mixer);
    }
}

