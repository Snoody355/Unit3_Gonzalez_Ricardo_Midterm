using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour, IPuzzlePiece
{
    //[SerializeField] private List<Rigidbody> correctRigidbodies = new List<Rigidbody>;
    [SerializeField] private UnityEvent OnActivate;
    [SerializeField] private UnityEvent OnDeactivate;
    [SerializeField] private Rigidbody correctRigidbody;

    private bool isCorrectRigidbodyOn;

public bool IsCorrect { get => isCorrectRigidbodyOn; set => isCorrectRigidbodyOn = value; }

    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody == correctRigidbody)
        {
            isCorrectRigidbodyOn = true;
            Debug.Log("I activated");
            OnActivate.Invoke();
        }

        

        // if (correctRigidbodies.Contains(other.attachedRigidbody))
        //{
        //
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody == correctRigidbody)
        {
            isCorrectRigidbodyOn = false;
            OnDeactivate.Invoke();
        }
    }
}
