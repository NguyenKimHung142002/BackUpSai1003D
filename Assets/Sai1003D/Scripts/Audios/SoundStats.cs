
using System;
using UnityEngine;
[Serializable]
public class  SoundStats 
{
    public SoundNameEn soundNameEn; 
    public AudioClip clip;
    [Range(0, 1)]
    public float volume = 1;
    [Range(0.1f, 3f)]
    public float pitch = 1;
    public bool playOnAwake = true;
    public bool loop = true;

    [HideInInspector]
    public AudioSource source;
}
