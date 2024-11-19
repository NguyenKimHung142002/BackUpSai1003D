using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : AutoMonoBehaviour
{
    [SerializeField] protected List<SoundStats> lSoundStats;
    protected static AudioManager instance;
    [SerializeField] public static AudioManager Instance {get => instance;}
    protected override void Start()
    {
         
        FindAndPlay(SoundNameEn.MainTheme);
    }
    protected override void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (AudioManager.instance != null) Debug.LogError("Only 1 Instance at time");
        AudioManager.instance = this;
        foreach (SoundStats s in lSoundStats)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }
    }

    public void FindAndPlay(SoundNameEn name)
    {
        SoundStats s = GetClip(name);
        if (s == null)
        {
            Debug.LogWarning(name.ToString() + " Audio is Not Found!");
            return;
        }
        this.Play(s);
    }
    public void Play(SoundStats s)
    {
        s.source.Play();
    }
    public SoundStats GetClip(SoundNameEn name)
    {
        foreach (SoundStats s in lSoundStats)
        {
            if (s.soundNameEn == name)
                return s;
        }

        return null;
    }

}
