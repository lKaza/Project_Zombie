using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHP=100f;
    
    
    private float currentHP;
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDmg(float dmg){
        currentHP -=dmg;
        if(currentHP <=0){
           GetComponent<DeathHandler>().HandleDeath();
            
        }
    }

    private void DeathSequence()
    {
      

    }
}
