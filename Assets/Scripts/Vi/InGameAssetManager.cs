using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameAssetManager : GameAssetManager
{

    private static InGameAssetManager _i;
    public static InGameAssetManager i
    {
        get
        {
            if (_i == null)
            {
                _i = FindObjectOfType<InGameAssetManager>();
            }
            return _i;
        }
    }

    public List<InGame_Music> inGame_Musics = new List<InGame_Music>();

    [System.Serializable]
    public class InGame_Music
    {
        public SoundManager.InGameMusic sound;
        public AudioClip audioClip;
    }

    public GameObject player;
    public Light flashLight;
    public GameObject startPoint;
    public GameObject buttonE;
    public GameObject inventory;
    public GameObject settingPanel;
    public GameObject itemPrefab;
    public Text bulletText;
    public Image inventoryBG;

    public GameObject text3D;
    public Text itemName_InInventory;

    public GameObject detailDescriptionPanel;
    public Text itemName_Detail;
    public Text itemDescription_Deatil;
    public Image itemSprite_Detail;

    public Gun gunScript;

    public void ExitGame() {
        SceneControlle.ExitGame();
    }
}
