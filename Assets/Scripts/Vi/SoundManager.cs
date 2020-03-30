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

    }

    public enum UI_SoundEffects {
        UI_Press,
        UI_HighLight,
        UI_Cancel,
        UI_Back,
        UI_OpenInventory,
        UI_ESC,
    }

    private static GameObject audioObject;
    private static AudioSource audioSource;

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
}
