using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Door : MonoBehaviour
{
    Animator anim;
    public bool canOpen = true;
    private bool _isOpening;
    public bool isOpening { set { _isOpening = value; } get { return _isOpening; } }
    public bool canClose = false;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    public void OpenDoor(bool b) {
        _isOpening = b;
        anim.SetBool("Open", b);
        SoundManager.PlaySound(SoundManager.SoundEffects.DoorOpen);
    }

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
