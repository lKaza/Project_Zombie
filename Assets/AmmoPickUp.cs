using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{

    [SerializeField] AmmoType ammoType;
    [SerializeField] int ammoQuantity=5;

    private void OnTriggerEnter(Collider other) {
        
        FindObjectOfType<Ammo>().AddAmmo(ammoType,ammoQuantity);
        Destroy(this.gameObject);
    }
}
