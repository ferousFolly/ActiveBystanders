using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private float distanceToShowRunUI;
    [SerializeField]
    private bool firstShow = true;
    public FirstPersonAIO AIO;
    public GameObject UI_Movement;
    public GameObject UI_Run;
    public GameObject UI_Flashlight;
    private Vector3 startPoint;

    [SerializeField]
    float runSpeed;
    
    void Start()
    {
        startPoint = InGameAssetManager.i.startPoint.transform.position;
        distanceToShowRunUI = InGameAssetManager.i.startPoint.GetComponent<GizmosDisplay>().radius;
        runSpeed = AIO.sprintSpeed;
    }

    void Update()
    {
        if (firstShow)
        {
            float dis = Vector3.Distance(startPoint, InGameAssetManager.i.player.transform.position);
            if (dis > distanceToShowRunUI)
            {
                AIO.sprintSpeed = runSpeed;
                UI_Movement.SetActive(false);
                UI_Run.SetActive(true);
                UI_Flashlight.SetActive(false);
            }
            else {
                AIO.sprintSpeed = AIO.walkSpeed;
            }
            if (GameEventManager.GetOpeningDoorNumbers() >= 1)
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
            AIO.sprintSpeed = runSpeed;
        }
    }
}
