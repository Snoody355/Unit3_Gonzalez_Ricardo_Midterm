using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorCheck : MonoBehaviour
{
    [SerializeField] private KeyCard card;
   
    [SerializeField] private DoorAnimation door;
    [SerializeField] private bool isLocked;
    private bool isopen;

    private void Start()
    {
        card.OnCardCollect.AddListener(UnlockDoor);
        isLocked = true;
        isopen = false;
            
    }

    private void UnlockDoor()
    {
        isLocked = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isLocked)
        {
            Debug.Log("Opening Door");
            door.OpenDoor();
            isopen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isopen)
        {
            door.CloseDoor();
            isopen = false;
        }
    }
}
