using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{
    private TurretState currentState;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private float rayDistance;
    [SerializeField] private LayerMask player;
    [SerializeField] private LayerMask triggers;
    [SerializeField] private int Damage;

    [SerializeField] private LineRenderer Lazer;
    private bool isActivated;

    private float damageCooldownTimer;
    
    // Start is called before the first frame update
    private void Start()
    {
        Lazer.SetPosition(0, shootingPoint.position);
        Lazer.SetPosition(1, shootingPoint.position);
    }

    // Update is called once per frame
    private void Update()
    {
        if (isActivated)
        {
            ActivateTurret();
        }
        
       
    }

    public void ActivateTurret()
    {
        Ray ray = new Ray(shootingPoint.position, shootingPoint.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~triggers))
        {
            Lazer.SetPosition(1, hit.point);
            
            if (hit.collider.TryGetComponent(out HealthModules target))
            {
                if (damageCooldownTimer >= 0)
                {
                    //cooldown activated
                    damageCooldownTimer -= Time.deltaTime;
                }
                else
                {
                    damageCooldownTimer = 1f;

                    if (target != null)
                    {
                        target.Damage(Damage);
                    }

                }
            }
        }
        
        
    }

    public void DeActivateTurret()
    {
        Lazer.SetPosition(0, shootingPoint.position);
        Lazer.SetPosition(1, shootingPoint.position);
    }


    public void boolActivate(bool active)
    {
        isActivated = active;
    }

    public void ChangeState(TurretState state)
    {
        if(currentState != null)
        {
            currentState.OnStateExit();
        }

        currentState = state;
        currentState.OnStateEnter();
    }

}
