using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] Color color = new Color(1, 1, 0, 0.75F);
    bool isProvoked= false;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        startPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position,transform.position);
        if(isProvoked){
           EngageTarget();
        }else if(distanceToTarget<=chaseRange){
            isProvoked = true;
           
        }else{
            navMeshAgent.SetDestination(startPosition);
        }
        
    }

    private void EngageTarget()
    {
        if(distanceToTarget >= navMeshAgent.stoppingDistance){
            chaseTarget();
        }
        if(distanceToTarget <= navMeshAgent.stoppingDistance){
            AttackTarget();
        }
    }

  

    private void chaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
        
    }
    private void AttackTarget()
    {
       print("im doing it");
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = color;
        Gizmos.DrawWireSphere(transform.position, chaseRange);

    }
}
