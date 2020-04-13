using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonOnly : MonoBehaviour
{
    private void OnMouseEnter()
    {
        GameEventManager.isEncounterDemon = true;
    }
}
