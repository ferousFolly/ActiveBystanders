using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigger : MonoBehaviour {
    public Transform triggerBox;
    public GameObject portalCamera;
    public GameObject portal;

    void OnCollisionEnter() {
        if (!portal.activeInHierarchy) {
            portal.SetActive(true);
            portalCamera.SetActive(true);
        }
    }
}
