using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : MonoBehaviour
{
    Transform player;
    public GameObject Livingoom;
    public GameObject LivingoomSwap;

    public GameObject Bathroom;
    public GameObject BathroomSwap;

    public GameObject Basement;
    public GameObject BasementSwap;

    public GameObject SmallBedroom;
    public GameObject SmallBedroomSwap;


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
            Livingoom.SetActive(LivingoomSwap.activeInHierarchy);
            LivingoomSwap.SetActive(!Livingoom.activeInHierarchy);
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
    }
}
