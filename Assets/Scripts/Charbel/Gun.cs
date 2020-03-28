using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    Animator anim;

    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;
    public LayerMask enemyBody;
    public LayerMask enemyHead;
    public GameObject hitEffect;
    public ParticleSystem muzzleFlash;

    private Camera fpsCam;
    public float nextTimeToFire = 1f;
    float currentTimeToFire;

    private void Start()
    {
        anim = GetComponent<Animator>();
        fpsCam = Camera.main;
    }

    void Update()
    {
        if (currentTimeToFire <= nextTimeToFire) {
            currentTimeToFire += Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire1") && currentTimeToFire >= nextTimeToFire)
        {
            Debug.Log("sss");
            currentTimeToFire = 0;
            shoot();

            muzzleFlash.Play();


        }
    }

    void shoot()
    {
        anim.SetTrigger("Shot1");
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, enemyBody))
        {
            AIDemon AI = hit.transform.GetComponentInParent<AIDemon>();
            if (AI != null && !AI._isDead) {
                AI.GetHit(10);
                GameObject o = Instantiate(hitEffect,hit.point,hitEffect.transform.rotation);
                Destroy(o,2f);
            }
    
        } else if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, enemyHead)) {
            AIDemon AI = hit.transform.GetComponentInParent<AIDemon>();
            if (AI != null && !AI._isDead)
            {
                AI.GetHit(20);
                GameObject o = Instantiate(hitEffect, hit.point, hitEffect.transform.rotation);
                Destroy(o, 2f);
            }
        }
    }
}
