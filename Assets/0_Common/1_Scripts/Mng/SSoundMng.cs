using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSoundMng : MonoBehaviour
{
    public AudioSource MainAudio = null;
    [SerializeField]
    AudioSource EffectAudio = null;
    [SerializeField]
    AudioSource EffectAudio2 = null;
    [SerializeField]
    AudioClip[] SoundClip = null;

    private static SSoundMng _Instance = null;

    public bool bBackGroundSound;       // true 배경음악 나옴 false 안나옴
    public bool bEffectSound;           // true 효과음 나옴 false 안나옴
    public static SSoundMng I
    {
        get
        {
            if (_Instance == null)
            {
                Debug.Log("instance is null");
            }
            return _Instance;
        }
    }

    void Awake()
    {
        _Instance = this;
        DontDestroyOnLoad(transform.gameObject);
    }

    public void Play(string sSoundName, bool bEffectAudio, bool bAutoPlay)
    {
        if (bAutoPlay.Equals(true))
        {
            MainAudio.playOnAwake = true;
            MainAudio.loop = true;
        }
        else
        {
            MainAudio.playOnAwake = false;
            MainAudio.loop = false;
        }

        for (int i = 0; i < SoundClip.Length; i++)
        {
            if (!bEffectAudio && SoundClip[i].name.Equals(sSoundName))
            {
                MainAudio.clip = SoundClip[i];
                MainAudio.Play();
            }
            else if (!EffectAudio.isPlaying && bEffectAudio && SoundClip[i].name.Equals(sSoundName))
            {
                EffectAudio.clip = SoundClip[i];
                EffectAudio.Play();
            }
            else if (EffectAudio.isPlaying && bEffectAudio && SoundClip[i].name.Equals(sSoundName))
            {
                EffectAudio2.clip = SoundClip[i];
                EffectAudio2.Play();
            }
        }
    }

    public void Stop()
    {
        MainAudio.Stop();
    }

    void SoundOff()
    {
        if (bBackGroundSound)
        {
            MainAudio.enabled = true;
            MainAudio.Play();
        }
        else
        {
            MainAudio.enabled = false;
        }

        if (bEffectSound)
        {
            EffectAudio.enabled = true;
            EffectAudio2.enabled = true;
        }
        else
        {
            EffectAudio.enabled = false;
            EffectAudio2.enabled = false;
        }
    }
}
