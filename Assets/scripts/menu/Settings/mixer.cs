using UnityEngine;
using UnityEngine.Audio;

public class mixer : MonoBehaviour
{
    public AudioMixer AudioMixer;

    public void Setvolume(float volume)
    {
        AudioMixer.SetFloat("volume", volume);
    }
}
