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

    public GameObject player;
    public Light flashLight;
    public GameObject startPoint;
    public GameObject buttonE;
    public GameObject inventory;
    public GameObject itemPrefab;
    public Text bulletText;
}
