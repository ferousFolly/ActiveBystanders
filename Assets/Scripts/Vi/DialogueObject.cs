using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueObject : MonoBehaviour
{
    public bool isTrigger;

    private void OnDestroy()
    {
        isTrigger = true;
    }
}
