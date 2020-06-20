using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShowRange : MonoBehaviour
{
    [SerializeField] Color color = new Color(1, 1, 0, 0.75F);
    
    private void Start() {
        
    }
    
    // Start is called before the first frame update
    public float chaseRange = 5.0f;

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = color;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        
    }
}
