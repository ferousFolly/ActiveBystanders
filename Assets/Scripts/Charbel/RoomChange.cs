using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : MonoBehaviour
{
    Transform player;

    public GameObject LivingRoom;
    public GameObject LivingRoomSwap;

    public GameObject Bathroom;
    public GameObject BathroomSwap;


    public GameObject Basement;
    public GameObject BasementSwap;


    public GameObject SmallBedroom;
    public GameObject SmallBedroomSwap;

    public GameObject Dinningroom;
    public GameObject DinningroomSwap;


     public bool PlayerIsStraight;

    BoxCollider collider;


    private void Start()
    {
        collider = GetComponent<BoxCollider>();
        collider.enabled = false;
        player = FindObjectOfType<FirstPersonAIO>().transform;
       
    }

    private void Update()
    {
        Vector3 posDiff = player.position - transform.position;
        float dotPos = Vector3.Dot(transform.forward, posDiff);
        if (dotPos < -2f)
        {
            collider.enabled = true;
        }

        else if (dotPos > 1)
        {
            collider.enabled = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {

            LivingRoom.SetActive(LivingRoomSwap.activeInHierarchy);
            LivingRoomSwap.SetActive(!LivingRoom.activeInHierarchy);
        }
        if (other.tag == "Player")
        {
            Bathroom.SetActive(BathroomSwap.activeInHierarchy);
            BathroomSwap.SetActive(!Bathroom.activeInHierarchy);
        }
        if (other.tag == "Player")
        {
            Basement.SetActive(BasementSwap.activeInHierarchy);
            BasementSwap.SetActive(!Basement.activeInHierarchy);

        }
        if (other.tag == "Player")
        {
            SmallBedroom.SetActive(SmallBedroomSwap.activeInHierarchy);
            SmallBedroomSwap.SetActive(!SmallBedroom.activeInHierarchy);
        }
        if (other.tag == "Player")
        {
            Dinningroom.SetActive(DinningroomSwap.activeInHierarchy);
            DinningroomSwap.SetActive(!Dinningroom.activeInHierarchy);
        }



    }
}
