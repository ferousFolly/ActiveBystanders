using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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

<<<<<<< HEAD
    const int maxBullets = 6;
    int currentBullets = 3;
=======
    public GameObject BloodEffect;
>>>>>>> Mercurius

    private Camera fpsCam;
    public float nextTimeToFire = 1f;
    float currentTimeToFire;

    private AudioSource Gunshot;

    private void Start()
    {
        anim = GetComponent<Animator>();
        fpsCam = Camera.main;
        currentBullets = 3;
    }

    void Update()
    {
        InGameAssetManager.i.bulletText.text = currentBullets.ToString() + "/" + maxBullets.ToString();
        if (currentTimeToFire <= nextTimeToFire) {
            currentTimeToFire += Time.deltaTime;
           
        }
        if (Input.GetButtonDown("Fire1") && currentTimeToFire >= nextTimeToFire && currentBullets > 0)
        {
            currentTimeToFire = 0;
            shoot();
            muzzleFlash.Play();
        }
    }

    void shoot()
    {
        anim.SetTrigger("Shot1");
        SoundManager.PlaySound(SoundManager.SoundEffects.GunShot);
        currentBullets -= 1;
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, enemyBody))
        {
            AIDemon AI = hit.transform.GetComponentInParent<AIDemon>();
            if (AI != null && !AI._isDead) {
                AI.GetHit(10);
                GameObject o = Instantiate(hitEffect,hit.point,hitEffect.transform.rotation);
                Destroy(o,2f);
                Instantiate(BloodEffect, hit.point, Quaternion.identity);
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
