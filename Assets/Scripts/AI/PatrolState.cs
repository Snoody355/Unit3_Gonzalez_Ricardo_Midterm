using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : AIState
{
     private int WaypointIndex;
     private float distanceToStop;

    public PatrolState(AIController aicontroller) : base(aicontroller)
    {
        distanceToStop = 1;
    }

    public override void OnStateEnter()
    {
        controller.GetAgent().SetDestination(controller.GetWaypoint(WaypointIndex).position);
    }

    public override void OnStateExit()
    {
        
    }

    public override void OnStateRun()
    {
        if (controller.GetAgent().remainingDistance < distanceToStop)
        {
            WaypointIndex++;
            if (WaypointIndex >= controller.TotalAmountOfWaypoints())
            {
                WaypointIndex = 0;
            }
            controller.GetAgent().SetDestination(controller.GetWaypoint(WaypointIndex).position);
        }
    }
}
