using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thompson : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float range=100;
    bool hitSomething;
    Animator myAnim;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
            Shoot();
        }
    }
    private void LateUpdate() {
        myAnim.SetBool("BoltOpen", false);
    }

    private void Shoot()
    {
        RaycastHit hit;
        AnimShoot();
        hitSomething = Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range);
        if (hitSomething)
        {
            print("i shoot dicks" + hit.transform.name);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
        }

    }

    private void AnimShoot()
    {
        myAnim.SetBool("BoltOpen", true);
        myAnim.SetTrigger("Fire");
    }
}
