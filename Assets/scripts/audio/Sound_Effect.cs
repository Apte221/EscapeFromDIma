using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Effect : MonoBehaviour
{
    public AudioClip soundClip;  // Àóä³îêë³ï, ÿêèé áóäå â³äòâîðþâàòèñÿ
    private AudioSource audioSource;  // Êîìïîíåíò AudioSource

    void Start()
    {
        // Îòðèìóºìî êîìïîíåíò AudioSource
        audioSource = GetComponent<AudioSource>();
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
