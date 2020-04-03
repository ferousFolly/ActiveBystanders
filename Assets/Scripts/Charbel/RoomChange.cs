using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : MonoBehaviour
{
    Transform player;
<<<<<<< HEAD
    public GameObject LivingRoom;
    public GameObject LivingRoomSwap;
=======
    public GameObject Livingoom;
    public GameObject LivingoomSwap;

    public GameObject Bathroom;
    public GameObject BathroomSwap;
>>>>>>> master

    public GameObject Basement;
    public GameObject BasementSwap;

<<<<<<< HEAD
    public GameObject BathRoom;
    public GameObject SmallRoom;

    public GameObject BathRoomSwap;
    public GameObject SmallRoomSwap;
=======
    public GameObject SmallBedroom;
    public GameObject SmallBedroomSwap;

>>>>>>> master

    bool isTrigger;

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
        float dotPos = Vector3.Dot(transform.forward,posDiff);
        if (dotPos < -2f)
        {
            collider.enabled = true;

            
        }
        else if(dotPos > 1)
        {
            collider.enabled = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
<<<<<<< HEAD
            LivingRoom.SetActive(LivingRoomSwap.activeInHierarchy);
            LivingRoomSwap.SetActive(!LivingRoom.activeInHierarchy);
        }

=======
            Livingoom.SetActive(LivingoomSwap.activeInHierarchy);
            LivingoomSwap.SetActive(!Livingoom.activeInHierarchy);
        }
        if (other.tag == "Player")
        {
            Bathroom.SetActive(BathroomSwap.activeInHierarchy);
            BathroomSwap.SetActive(!Bathroom.activeInHierarchy);
        }
>>>>>>> master
        if (other.tag == "Player")
        {
            Basement.SetActive(BasementSwap.activeInHierarchy);
            BasementSwap.SetActive(!Basement.activeInHierarchy);
<<<<<<< HEAD
=======
        }
        if (other.tag == "Player")
        {
            SmallBedroom.SetActive(SmallBedroomSwap.activeInHierarchy);
            SmallBedroomSwap.SetActive(!SmallBedroom.activeInHierarchy);
>>>>>>> master
        }

        if (other.tag == "Player")
        {
            BathRoom.SetActive(SmallRoom.activeInHierarchy);
            SmallRoom.SetActive(!BathRoom.activeInHierarchy);
        }

        if (other.tag == "Player")
        {
            SmallRoomSwap.SetActive(BathRoomSwap.activeInHierarchy);
            BathRoomSwap.SetActive(!SmallRoomSwap.activeInHierarchy);
        }

    }
}
