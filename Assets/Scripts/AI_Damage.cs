using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Damage : MonoBehaviour {

    public int AI_bar = 30;
    int Damage = 10;

    // Start is called before the first frame update
    void Start() {
        print(AI_bar);
    }

    private void OnTriggerEnter(Collider other) {
        other.gameObject.GetComponent<AI_Health>().TakeDamage(Damage);

    }
}
