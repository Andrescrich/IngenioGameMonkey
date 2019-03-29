using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;

public class AudioManagerScript : MonoBehaviour
{

    public Sound[] sounds;

    private void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }


    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Play("Base1");
            Play("Melodia1");
        }
        else if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            Invoke("DelayMusica", 1.15f);
            Play("IntroMelodia");
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) return;
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) return;
        s.source.Stop();
    }

    void DelayMusica()
    {
        Play("Base1");
        Play("Melodia1");
    }
}
