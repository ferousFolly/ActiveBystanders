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

    int maxBullets;
    int currentBullets = 3;
    [SerializeField]
    bool isReloading;
    public float reload1BulletTime;
    float currentReloadTime;

    private Camera fpsCam;
    public float nextTimeToFire = 1f;
    float currentTimeToFire;

    private void Start()
    {
        anim = GetComponent<Animator>();
        fpsCam = Camera.main;
        maxBullets = 3;
        currentBullets = 3;
    }

    void Update()
    {
        InGameAssetManager.i.bulletText.text = currentBullets.ToString() + "/" + maxBullets.ToString();
        if (currentTimeToFire <= nextTimeToFire) {
            currentTimeToFire += Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire1") && currentTimeToFire >= nextTimeToFire && currentBullets > 0 && !isReloading)
        {
            currentTimeToFire = 0;
            shoot();
            muzzleFlash.Play();
        }


        if (Input.GetKeyDown(KeyCode.R) && maxBullets > 0 && !isReloading)
        {
            anim.SetTrigger("OpenReloader");
            isReloading = true;
        } else if (currentBullets == 0 && maxBullets > 0 && !isReloading) {
            anim.SetTrigger("OpenReloader");
            isReloading = true;
        }

        if (isReloading) {
            Reload();
        }
    }

    void shoot()
    {
        anim.SetTrigger("Shot1");
        SoundManager.PlaySound(SoundManager.SoundEffects.Gun_Shot);
        currentBullets -= 1;
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, enemyBody))
        {
            AI_Base AI = hit.transform.GetComponentInParent<AI_Base>();
            if (AI != null && !AI.isDead)
            {
                AI.GetHit();
                GameObject o = Instantiate(hitEffect, hit.point, hitEffect.transform.rotation);
                Destroy(o, 2f);
            }
        } else if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, enemyHead)) {
            AI_Base AI = hit.transform.GetComponentInParent<AI_Base>();
            if (AI != null && !AI.isDead)
            {
                AI.GetHit();
                GameObject o = Instantiate(hitEffect, hit.point, hitEffect.transform.rotation);
                Destroy(o, 2f);
            }
        }
        StartCoroutine(SoundManager.PlaySound(SoundManager.SoundEffects.Gun_BulletFalling,0.5f));
    }

    void Reload()
    {
        if (maxBullets > 0)
        {
            if (currentReloadTime < reload1BulletTime)
            {
                currentReloadTime += Time.deltaTime;
            }
            else
            {
                SoundManager.PlaySound(SoundManager.SoundEffects.Gun_ReloadBullet);
                maxBullets -= 1;
                currentBullets += 1;
                currentReloadTime = 0;
            }
        }
        else {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("OpenReloader") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.95f)
            {
                StartCoroutine(SoundManager.PlaySound(SoundManager.SoundEffects.Gun_CloseReloader, 0.65f));
                anim.SetTrigger("CloseReloader");
            }
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("CloseReloader") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.95f)
        {
            //SoundManager.PlaySound(SoundManager.SoundEffects.Gun_CloseReloader);
            isReloading = false;
        }
    }
}
