using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    public ParticleSystem muzzleFlash;
   
    void Start()
    {
        
    }

    
    void Update()
    {
        muzzleFlash.Play();
    }



}
