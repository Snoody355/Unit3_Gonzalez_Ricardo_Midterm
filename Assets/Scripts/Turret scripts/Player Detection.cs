using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField] private TurretShoot turret;

    private void OnTriggerEnter(Collider other)
    {
        turret.ChangeState(new AttackTurret(turret));
    }

    private void OnTriggerExit(Collider other)
    {
        turret.ChangeState(new IdleTurretState(turret));
    }
}
