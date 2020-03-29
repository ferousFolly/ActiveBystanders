using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : MonoBehaviour
{
    public  Transform player;
    public GameObject SwapTrigger;
    public bool _LivingRoom = false;
    public bool LivingRoomSwap = false;


    // Start is called before the first frame update

    public void OnTriggerEnter(Collider other)
    {
        if (SwapTrigger)
        {
            _LivingRoom = true;
        }
        else
            LivingRoomSwap = false;


    }

    private void OnTriggerExit(Collider other)
    {
        if (SwapTrigger)
        {
            LivingRoomSwap = true;
        }
        else
            _LivingRoom = false;
       
        
    }
}
