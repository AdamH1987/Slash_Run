using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] Sounds;
 
    public static AudioManager instance;

    public void Start()
    {
        float musicSliderVol = 0;

        if (PlayerPrefs.HasKey("musicVol") == true)
        {
            musicSliderVol = PlayerPrefs.GetFloat("musicVol");
        }
        else
        {
            PlayerPrefs.SetFloat("musicVol", 0.5f);
        }
    }




    void Awake ()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in Sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;

            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(Sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
                return;
        }
            
        s.audioSource.Play();
    }
}
