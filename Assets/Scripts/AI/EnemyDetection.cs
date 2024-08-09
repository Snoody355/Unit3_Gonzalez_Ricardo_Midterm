using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{

    [SerializeField] private AIController controller;
    private void OnTriggerEnter(Collider other)
    {
        controller.ChangeAIState(new ChaseState(other.transform, controller)); 
    }
}
