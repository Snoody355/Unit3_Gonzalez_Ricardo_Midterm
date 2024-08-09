using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTurretState : TurretState
{
    public override void OnStateEnter()
    {
        turret.boolActivate(false);

        turret.DeActivateTurret();
    }

    public override void OnStateExit()
    {
        
    }

    public override void OnStateRun()
    {
        
    }

    public IdleTurretState(TurretShoot thisturret) : base(thisturret)
    {
        turret = thisturret;
    }
}
