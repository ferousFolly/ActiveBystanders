using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : MonoBehaviour
{
    Transform player;
    public GameObject originalLayout;
    public GameObject newLayout;
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
            originalLayout.SetActive(newLayout.activeInHierarchy);
            newLayout.SetActive(!originalLayout.activeInHierarchy);
        }
    }
}
