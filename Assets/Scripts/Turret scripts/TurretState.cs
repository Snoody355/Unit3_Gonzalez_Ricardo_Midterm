using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurretState
{
    protected TurretShoot turret;
    public abstract void OnStateEnter();

    public abstract void OnStateRun();

    public abstract void OnStateExit();

    public TurretState(TurretShoot currentTurret)
    {
        turret = currentTurret;
    }
}
