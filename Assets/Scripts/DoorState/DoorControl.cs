using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void OpenDoor()
    {
        animator.SetBool("DoorOpem", true);
    }

    public void CloseDoor()
    {
        animator.SetBool("DoorOpem", false);
    }

    public void DynamicOpenCloseDoor()
    {
        if (animator.GetBool("DoorOpem"))
        {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }
    }
}
