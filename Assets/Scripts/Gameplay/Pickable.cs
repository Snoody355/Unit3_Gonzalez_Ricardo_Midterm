using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour, IInteractable

{
    
    [SerializeField] private Rigidbody myRigidbody;

    [SerializeField] private Transform startingParent;

    private bool isPicked = false;

    private FixedJoint joint;

    private void Start()
    {
        startingParent = transform.parent;
    }

    public void Interact(PlayerInput interactor)
    {
        Debug.Log(transform.parent);
        if(!isPicked)
        {


            //joint = gameObject.AddComponent<FixedJoint>();
            //joint.connectedBody = interactor.GetPlayerRigidbody();

            myRigidbody.useGravity = false;
            myRigidbody.isKinematic = true;

            transform.position = interactor.GetPickUpLoactation().position;
            transform.rotation = interactor.GetPickUpLoactation().rotation;
            transform.SetParent(interactor.GetPickUpLoactation());
            isPicked = true;
            

        }
        else
        {
            transform.SetParent(startingParent);

            myRigidbody.useGravity = true;
            myRigidbody.isKinematic = false;

            isPicked = false;

        }



    }

  

    public void OnHoverEnter()
    {


    }

    public void OnHoverExit()
    {

    }
}
