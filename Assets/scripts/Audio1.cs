using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio1 : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip deephitpan;
    public AudioClip deepincoming;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void PlaySoundEffect()
    {
        audioSource.PlayOneShot(deephitpan, 0.9f);
        audioSource.PlayOneShot(deepincoming, 0.9f);
    }

}    



