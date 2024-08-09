using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class HealthModules : MonoBehaviour
{
    [SerializeField] private int MaxHealthPoints;
    private int healthPoints;
    


    public UnityEvent<int> OnHealthChaged;
    public UnityEvent  OnDie;
    //public Action<int> OnCsharpHealthChanged;
    // Start is called before the first frame update
    void Start()
    {
        healthPoints = MaxHealthPoints;
        GameManager.Singleton.OnRespawn.AddListener(Respawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damageCaused)
    {
        healthPoints -= damageCaused;
        OnHealthChaged.Invoke(healthPoints);
        if ( healthPoints <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        OnDie.Invoke();
        GameManager.Singleton.DeadPlayer();
    }

    void Respawn()
    {
        healthPoints = MaxHealthPoints;
        OnHealthChaged.Invoke(healthPoints);
    }

}
