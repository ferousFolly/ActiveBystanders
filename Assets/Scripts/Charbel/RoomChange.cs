using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : MonoBehaviour
{
    Transform player;
    public GameObject LivingRoom;
    public GameObject LivingRoomSwap;

    public GameObject Basement;
    public GameObject BasementSwap;

    public GameObject BathRoom;
    public GameObject SmallRoom;

    public GameObject BathRoomSwap;
    public GameObject SmallRoomSwap;

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
            LivingRoom.SetActive(LivingRoomSwap.activeInHierarchy);
            LivingRoomSwap.SetActive(!LivingRoom.activeInHierarchy);
        }

        if (other.tag == "Player")
        {
            Basement.SetActive(BasementSwap.activeInHierarchy);
            BasementSwap.SetActive(!Basement.activeInHierarchy);
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
