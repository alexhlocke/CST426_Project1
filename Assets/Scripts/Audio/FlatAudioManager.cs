using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class FlatAudioManager : MonoBehaviour
{
    public FlatSound[] sounds;

    void Awake() {
        foreach (FlatSound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start() {
        //playFlatSound("music");
    }

    public void playFlatSound(string name) {
        FlatSound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
