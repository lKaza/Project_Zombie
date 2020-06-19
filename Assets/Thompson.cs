using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thompson : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float range=100;
    [SerializeField] float weaponDmg=10f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;

    bool hitSomething;
    Animator myAnim;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        WeaponZoom zoom = FindObjectOfType<WeaponZoom>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Shoot();
        }
        
    } 
    private void LateUpdate() {
        myAnim.SetBool("BoltOpen", false);
    }

    private void Shoot()
    {
        if(ammoSlot.GetCurrentAmmo()>0){
            AnimShoot();
            VFXMuzzleFlash();
            RayCastProcess();
            SpendAmmo();
        }
       

    }

    private void SpendAmmo()
    {
        ammoSlot.SpendAmmo();
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
