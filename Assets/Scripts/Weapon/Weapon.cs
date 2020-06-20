using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float range=100;
    [SerializeField] float weaponDmg=10f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] AmmoType ammoType;
    [SerializeField] Ammo ammoSlot;
    bool canShoot = true;
    [SerializeField] float timeBetweenShoots = 0.1f;

    bool hitSomething;
    Animator myAnim;
    
    private void OnEnable() {
        canShoot = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        WeaponZoom zoom = FindObjectOfType<WeaponZoom>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && canShoot){
            StartCoroutine(Shoot());
           
        }
        
    } 
    private void LateUpdate() {
        myAnim.SetBool("BoltOpen", false);
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if(ammoSlot.GetCurrentAmmo(ammoType)>0){

            AnimShoot();
            VFXMuzzleFlash();
            RayCastProcess();
            SpendAmmo();
        }
       
        yield return new WaitForSeconds(timeBetweenShoots);
        canShoot = true;
    }

    private void SpendAmmo()
    {
        ammoSlot.SpendAmmo(ammoType);
    }

    private void VFXMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void RayCastProcess()
    {
        RaycastHit hit;
        hitSomething = Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range);
        if (hitSomething)
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) { return; }
            target.TakeDmg(weaponDmg);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject  impact =Instantiate(hitEffect,hit.point,Quaternion.LookRotation(hit.normal));
        Destroy(impact,0.5f);
    }

    private void AnimShoot()
    {
        myAnim.SetBool("BoltOpen", true);
        myAnim.SetTrigger("Fire");
    }
}
