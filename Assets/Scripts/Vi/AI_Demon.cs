using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Demon : AI_Base
{
    private AudioSource audio;
    bool isScreaming;

    protected override void Start()
    {
        base.Start();
        audio = GetComponent<AudioSource>();
    }

    protected override void Persuing()
    {
        if (!isScreaming)
        {
            audio.PlayOneShot(SoundManager.GetAudioClip(SoundManager.SoundEffects.Demon_Scream));
            isScreaming = true;
        }
        else {
            if (!audio.isPlaying) {
                isScreaming = false;
            }
        }

        base.Persuing();
    }
}
