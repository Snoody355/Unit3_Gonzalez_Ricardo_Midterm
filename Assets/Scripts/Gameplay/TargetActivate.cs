using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetActivate : MonoBehaviour
{
    [SerializeField] private UnityEvent onHit;
    

    private void OnTriggerEnter(Collider other)
    {
        
        onHit.Invoke();
        
    }

    
}
