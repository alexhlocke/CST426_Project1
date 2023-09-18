using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class FlatSound
{
    public string name;
    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;
    [Range(.2f,2f)]
    public float pitch;
    public bool loop;

    //[HideInInspector]
    public AudioSource source;
}
