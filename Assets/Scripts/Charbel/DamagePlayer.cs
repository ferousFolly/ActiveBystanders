using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    public float DamageAmount = 10f;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            other.GetComponent<PlayerDying>().TakeDamage(DamageAmount);
        }
    }
}
