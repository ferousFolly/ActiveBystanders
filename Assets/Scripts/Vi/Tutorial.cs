using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private float distanceToShowRunUI;
    private bool firstShow = true;
    public GameObject UI_Movement;
    public GameObject UI_Run;
    public GameObject UI_Flashlight;
    private Vector3 startPoint;
    
    void Start()
    {
        startPoint = InGameAssetManager.i.startPoint.transform.position;
        distanceToShowRunUI = InGameAssetManager.i.startPoint.GetComponent<GizmosDisplay>().radius;
    }

    void Update()
    {
        if (firstShow)
        {
            float dis = Vector3.Distance(startPoint, InGameAssetManager.i.player.transform.position);
            if (dis > distanceToShowRunUI)
            {
                UI_Movement.SetActive(false);
                UI_Run.SetActive(true);
                UI_Flashlight.SetActive(false);
            }
            if (GameEventManager.GetOpeningDoorNumbers() == 1)
            {
                UI_Movement.SetActive(false);
                UI_Run.SetActive(false);
                UI_Flashlight.SetActive(true);
                GameEventManager.canUseFlashLight = true;
            }
            if (GameEventManager.GetFlashLightUsedNumbers() == 1)
            {
                UI_Movement.SetActive(false);
                UI_Run.SetActive(false);
                UI_Flashlight.SetActive(false);
                firstShow = false;
            }
        }
        else {
            UI_Movement.SetActive(false);
            UI_Run.SetActive(false);
            UI_Flashlight.SetActive(false);
        }
    }
}
