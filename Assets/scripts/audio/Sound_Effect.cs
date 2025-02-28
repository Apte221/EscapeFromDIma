using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Sound_Effect : MonoBehaviour
{
    public AudioClip soundClip;  // Àóä³îêë³ï, ÿêèé áóäå â³äòâîðþâàòèñÿ
    public AudioSource audioSource;  // Êîìïîíåíò AudioSource


    void Start()
    {
        // Îòðèìóºìî êîìïîíåíò AudioSource
        audioSource = GameObject.Find("Звук падіння")?.GetComponent<AudioSource>();
        
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
