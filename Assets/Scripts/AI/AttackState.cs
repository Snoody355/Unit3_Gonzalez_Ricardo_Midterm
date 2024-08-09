using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : AIState
{
    private Transform target;
    private HealthModules targetHealthModule;

    private float damageCooldownTimer;
    

    public AttackState(AIController aicontroller, Transform newTarget) : base(aicontroller)
    {
        target = newTarget;
    }

    public override void OnStateEnter()
    {
        targetHealthModule = target.GetComponent<HealthModules>();
    }

    public override void OnStateExit()
    {
        
    }

    public override void OnStateRun()
    {
        if(damageCooldownTimer >= 0)
        {
            damageCooldownTimer -= Time.deltaTime;
        }
        else
        {
            if(targetHealthModule != null)
            {
                targetHealthModule.Damage(5);
            }
            damageCooldownTimer =3f;
        }

        

        if (Vector3.Distance(target.position, controller.transform.position) >= 2f)
        {
            controller.ChangeAIState(new ChaseState(target, controller));
        }
        
    }
}
