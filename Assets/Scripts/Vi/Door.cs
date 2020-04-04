using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Door : MonoBehaviour
{
    public bool canOpen = true;
    private bool _isOpening;
    public bool isOpening { set { _isOpening = value; } get { return _isOpening; } }
    public bool canClose = false;

    public bool CanOpenDoor() {
        if (canOpen && !_isOpening) {
            return true;
        }
        return false;
    }

    public bool CanCloseDoor() {
        if (canClose && _isOpening)
        {
            return true;
        }
        return false;
    }
}
