using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DoorState 
{
    protected DoorStateControl door;

    public abstract void OnStateEnter();

    public abstract void OnStateRun();

    public abstract void OnStateExit();

    public DoorState(DoorStateControl currentDoor)
    {
        door = currentDoor;
    }
}
