using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : AIState
{
    private Transform target;

    public ChaseState(Transform newTarget, AIController aicontroller) : base(aicontroller)
    {
        target = newTarget;
    }

    public override void OnStateEnter()
    {
        
    }

    public override void OnStateExit()
    {
        
    }

    public override void OnStateRun()
    {
        controller.GetAgent().SetDestination(target.position);
        if(controller.GetAgent().remainingDistance < 2f)
        {
            controller.ChangeAIState(new AttackState(controller, target));
        }
    }
}
