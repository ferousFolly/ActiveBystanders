using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Damage : MonoBehaviour
{

    public float damageAmount = 35;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player") {
            other.GetComponent<PlayerDying>().TakeDamage(damageAmount);
        }
    }
}
