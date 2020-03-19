using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public float health = 50;
    // Start is called before the first frame update
    public void TakeDamage (float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
    }

    void Die ()
    {
        Destroy(gameObject);
    }
}
