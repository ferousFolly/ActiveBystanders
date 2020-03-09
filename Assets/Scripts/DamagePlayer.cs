using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    public int PlayerHealth = 30;
    int Damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        print(PlayerHealth);
    }


    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<HealthBar>().TakeDamage(Damage);
    }
}
