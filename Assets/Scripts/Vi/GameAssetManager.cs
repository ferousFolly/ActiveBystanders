using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameAssetManager : MonoBehaviour
{
    private static GameAssetManager _i;
    public static GameAssetManager i
    {
        get
        {
            if (_i == null)
            {
                _i = FindObjectOfType<GameAssetManager>();
            }
            return _i;
        }
    }

    public SoundClip[] soundClipArray;
    public UI_SoundClip[] UI_SoundClipArray;
    //public VisualEffect[] visualEffectArray;

    [System.Serializable]
    public class SoundClip
    {
        public SoundManager.SoundEffects sound;
        public AudioClip audioClip;
    }


    [System.Serializable]
    public class UI_SoundClip
    {
        public SoundManager.UI_SoundEffects UI_sound;
        public AudioClip audioClip;
    }

    //[System.Serializable]
    //public class VisualEffect {
    //    public VisualEffectManager.VisualEffects visualEffectName;
    //    public GameObject visualEffectPrefab;
    //}
}
