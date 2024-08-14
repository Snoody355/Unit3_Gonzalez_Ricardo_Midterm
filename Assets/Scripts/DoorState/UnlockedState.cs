using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedState : DoorState
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

    public UnlockedState(DoorStateControl thisdoor) : base(thisdoor)
    {
        door = thisdoor;
    }
}
