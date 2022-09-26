using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : GenericSingleton<SoundManager>
{
    public AudioSource soundEffect;
    public AudioSource soundMusic;
    public SoundType[] Sounds;
    [SerializeField]
    bool isMute = false;
    public float volume = 1f;

    public bool IsMute { get => isMute; set => isMute = value; }

    private void Start()
    {
        SetVolume(0.25f);
        EventHandler.Instance.InvokeOnPlayBackGroundSound();    
    }

    private void OnEnable()
    {
        EventHandler.Instance.OnButtonClickSound += Play;
        EventHandler.Instance.OnPlayBackGroundSound += PlayMusic;
        EventHandler.Instance.OnMuteSound += Mute;
       
    }

    private void OnDisable()
    {
        EventHandler.Instance.OnButtonClickSound -= Play;
        EventHandler.Instance.OnPlayBackGroundSound -= PlayMusic;
        EventHandler.Instance.OnMuteSound -= Mute;
    }

    public void Mute ()
    {
        if(isMute == false)
        {
            isMute = true;
        }
        else
        {
            isMute = false;
        }

        EventHandler.Instance.InvokeOnPlayBackGroundSound();
        

    }

    public void SetVolume (float volume)
    {
        volume = this.volume;
        soundEffect.volume = volume;
        soundMusic.volume = volume;
    }

    public void PlayMusic (Sounds sound)
    {
        if (IsMute==true)
        {
            print("Background Sound " + IsMute.ToString());
            soundMusic.Stop();
            return;
        }    

        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            soundMusic.clip = clip;
            soundMusic.Play();
            soundMusic.loop = true;
        }
        else
        {
            Debug.LogError("Clip not Found for sound type: " + sound);
        }
    }

    public void Play(Sounds sound)
    {
        if (IsMute)
            return;

        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("Clip not Found for sound type: " + sound);
        }
    }

    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType item =  Array.Find(Sounds, i => i.soundType == sound);
        if (item != null)
            return item.soundClip;
        return null;
    }       

}


