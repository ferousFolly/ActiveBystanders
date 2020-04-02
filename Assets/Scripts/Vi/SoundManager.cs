using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    public enum SoundEffects {
        ItemPickUp,
        Hearbeat,
        Player_GetHurt,
        DoorOpen,
        GunShot,
        FlashOn,
        FlashOff,
    }

    public enum UI_SoundEffects {
        UI_Press,
        UI_HighLight,
        UI_Cancel,
        UI_Back,
        UI_OpenInventory,
        UI_ESC,
    }

    public enum InGameMusic {
        BeingTraced,
    }

    private static GameObject audioObject;
    private static GameObject musicAudioObject;
    private static AudioSource audioSource;
    private static AudioSource _musicAudioSoure;
    public static AudioSource musicAudioSource {
        get {
            return _musicAudioSoure;
        }
    }

    public static void PlaySound(SoundEffects sound) {
        if (audioObject == null)
        {
            audioObject = new GameObject("Sound");
            audioSource = audioObject.AddComponent<AudioSource>();
            //if (SettingManager.i.GetSoundEffectAudioMixer() != null) {
            //    audioSource.outputAudioMixerGroup = SettingManager.i.GetSoundEffectAudioMixer();
            //}
        }
        audioSource.PlayOneShot(GetAudioClip(sound));
    }

    public static void PlaySound(UI_SoundEffects sound)
    {
        if (audioObject == null)
        {
            audioObject = new GameObject("Sound");
            audioSource = audioObject.AddComponent<AudioSource>();
            //if (SettingManager.i.GetSoundEffectAudioMixer() != null)
            //{
            //    audioSource.outputAudioMixerGroup = SettingManager.i.GetSoundEffectAudioMixer();
            //}
        }
        audioSource.PlayOneShot(GetAudioClip(sound));
    }

    public static void PlaySound(InGameMusic sound)
    {
        if (musicAudioObject == null)
        {
            musicAudioObject = new GameObject("Music");
            _musicAudioSoure = musicAudioObject.AddComponent<AudioSource>();
        }
        _musicAudioSoure.PlayOneShot(GetAudioClip(sound));
    }




    private static AudioClip GetAudioClip(SoundEffects sound) {
        foreach (GameAssetManager.SoundClip soundClip in GameAssetManager.i.soundClipArray)
        {
            if (soundClip.sound == sound) {
                return soundClip.audioClip;
            }
        }
        Debug.LogError("AudioClip Not Found");
        return null;
    }

    private static AudioClip GetAudioClip(UI_SoundEffects sound)
    {
        foreach (GameAssetManager.UI_SoundClip soundClip in GameAssetManager.i.UI_SoundClipArray)
        {
            if (soundClip.UI_sound == sound)
            {
                return soundClip.audioClip;
            }
        }
        Debug.LogError("AudioClip Not Found");
        return null;
    }

    private static AudioClip GetAudioClip(InGameMusic sound)
    {
        foreach (InGameAssetManager.InGame_Music soundClip in InGameAssetManager.i.inGame_Musics)
        {
            if (soundClip.sound == sound)
            {
                return soundClip.audioClip;
            }
        }
        Debug.LogError("AudioClip Not Found");
        return null;
    }
}
