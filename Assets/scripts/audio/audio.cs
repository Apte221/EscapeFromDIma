using UnityEngine;

public class PlaySoundOnTrigger : MonoBehaviour
{
    public AudioClip soundClip;  // Àóä³îêë³ï, ÿêèé áóäå â³äòâîðþâàòèñÿ
    private AudioSource audioSource;  // Êîìïîíåíò AudioSource

    void Start()
    {
        // Îòðèìóºìî êîìïîíåíò AudioSource
        audioSource = GetComponent<AudioSource>();

        // Ïåðåâ³ðÿºìî, ÷è º êîìïîíåíò AudioSource íà îá'ºêò³
        if (audioSource == null)
        {
            Debug.LogError("AudioSource íå çíàéäåíèé! Äîäàéòå êîìïîíåíò AudioSource äî îá'ºêòà.");
        }

        // Ïåðåâ³ðêà ÷è º àóä³îêë³ï
        if (soundClip != null)
        {
            audioSource.clip = soundClip;
        }
        else
        {
            Debug.LogWarning("Àóä³îêë³ï íå çàäàíèé. Çâóê íå áóäå â³äòâîðþâàòèñÿ.");
        }
    }

    // Öåé ìåòîä ñïðàöþº, êîëè ³íøèé îá'ºêò ç êîëàéäåðîì óâ³éäå â òðèãåð
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Ïåðåâ³ðêà, ÷è öå ãðàâåöü
        {
            // Â³äòâîðþºìî çâóê
            if (audioSource != null && soundClip != null)
            {
                audioSource.Play();
            }
        }
    }
     private void OnCollisionEnter(Collision collision)
    {
        // Граємо звук тільки якщо швидкість падіння достатня
        if (collision.relativeVelocity.magnitude > 2)
        {
            audioSource.PlayOneShot(soundClip);
        }
    }
}
