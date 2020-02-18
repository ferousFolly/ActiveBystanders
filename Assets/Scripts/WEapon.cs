using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WEapon : MonoBehaviour
{

    void Update()
    {
        if (transform.parent != null) {
            transform.eulerAngles = Vector3.zero;
            if (GetComponent<Rigidbody>() != null) {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                GetComponent<Rigidbody>().useGravity = false;
            }
        }
    }
}
