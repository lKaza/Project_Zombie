using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float followSpeed = 5f;
    [SerializeField] Color color = new Color(1, 1, 0, 0.75F);
    bool isProvoked= false;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;

    Vector3 startPosition;
    Animator myAnim;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
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
    public void OnDamageTaken(){
        isProvoked= true;
    }

    private void EngageTarget()
    {
        FaceTarget();
        if(distanceToTarget >= navMeshAgent.stoppingDistance){
            chaseTarget();
        }
        if(distanceToTarget <= navMeshAgent.stoppingDistance){
            AttackTarget();
        }
    }

  

    private void chaseTarget()
    {
        myAnim.SetBool("attack",false);
        myAnim.SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
        
    }
    private void AttackTarget()
    {
        myAnim.SetBool("attack",true);
        
       
    }
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,followSpeed*Time.deltaTime);
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = color;
        Gizmos.DrawWireSphere(transform.position, chaseRange);

    }
}
