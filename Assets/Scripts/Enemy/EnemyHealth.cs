using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float maxHitPoints=100f;
    [SerializeField] NavMeshAgent navMesh;
    bool isAlive = true;
    Animator myAnim;
    private float currentHitPoints;
    
    // Start is called before the first frame update
    void Start()
    {
        
        currentHitPoints = maxHitPoints;
        myAnim = GetComponent<Animator>();
       
    }

    public void TakeDmg(float dmg){
        currentHitPoints -= dmg;
        BroadcastMessage("OnDamageTaken");
        if(currentHitPoints <=0 && isAlive)
        {
            isAlive = false;
            DeathSequence();
        }
    }

    private void DeathSequence()
    {
        myAnim.SetTrigger("isAlive");
        navMesh.enabled = false;
        Destroy(this.gameObject,5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
