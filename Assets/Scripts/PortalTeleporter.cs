using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public Transform player;
    public Transform reciver;
    private bool playerIsOverLapping = false;
    // Update is called once per frame
    void Update()
    {
        if (playerIsOverLapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            Vector3 potalToPlayer = default;
            float dotproduct = Vector3.Dot(transform.up, potalToPlayer);
            if (dotproduct < 0f)
            {
                float rotationDiff = -Quaternion.Angle(transform.rotation, reciver.rotation);
                rotationDiff += 100;
                
                player.Rotate(Vector3.up, rotationDiff);
                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = reciver.position + positionOffset;
                playerIsOverLapping = false;


            }
            
;        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))



            other.gameObject.transform.position = reciver.position;

        
    }
}
