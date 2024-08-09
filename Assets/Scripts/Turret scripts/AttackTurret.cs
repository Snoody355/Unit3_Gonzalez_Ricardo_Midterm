using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTurret : TurretState
{
    public override void OnStateEnter()
    {
        turret.boolActivate(true);
    }

    public override void OnStateExit()
    {
        
    }

    public override void OnStateRun()
    {
        
    }

    public AttackTurret(TurretShoot thisturret) : base(thisturret)
    {
        turret = thisturret;
    }
}

