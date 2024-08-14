using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedState : DoorState
{
    public override void OnStateEnter()
    {
        
    }

    public override void OnStateRun()
    {
        
    }

    public override void OnStateExit()
    {
        
    }

    public LockedState(DoorStateControl thisdoor) : base(thisdoor)
    {
        door = thisdoor;
    }

}
