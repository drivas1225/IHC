using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    float time = 0.0f;
    bool flag = false;
    // Start is called before the first frame update

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }



    void Start()
    {
        Play("music");
        Sound s = Array.Find(sounds, sound => sound.name == "music");
        Debug.Log(s.clip.name);
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= 20 && time < 30 && flag == false)
        {
            Stop("music");
            Sound s = Array.Find(sounds, sound => sound.name == "music");
            Sound saux = Array.Find(sounds, sound => sound.name == "music2");

            s.clip = saux.clip;
            s.source.clip = saux.source.clip;
            Play("music");
            flag = true;
        }
        else if (time >= 30 && flag == true)
        {
            Stop("music");
            Sound s = Array.Find(sounds, sound => sound.name == "music");
            Sound saux = Array.Find(sounds, sound => sound.name == "music3");

            s.clip = saux.clip;
            s.source.clip = saux.source.clip;
            Play("music");
            flag = false;
        }

    }


    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound " + name + " not found!");
            return;
        }
        s.source.Play();

    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound " + name + " not found!");
            return;
        }
        s.source.Stop();

    }

    public string GetClipName(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound " + name + " not found!");
            return "";
        }
        return s.clip.name;

    }
}