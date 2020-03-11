using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAI : MonoBehaviour
{


    public float DamageAmount = 10f;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AI")
        {
            other.GetComponent<PlayerDying>().TakeDamage(DamageAmount);

            Debug.Log("ssss");
        }

    }
}