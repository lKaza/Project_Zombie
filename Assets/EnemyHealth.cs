using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float maxHitPoints=100f;
    private float currentHitPoints;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHitPoints = maxHitPoints;
    }

    public void TakeDmg(float dmg){
        currentHitPoints -= dmg;

        if(currentHitPoints <=0)
        {
            DeathSequence();
        }
    }

    private void DeathSequence()
    {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
