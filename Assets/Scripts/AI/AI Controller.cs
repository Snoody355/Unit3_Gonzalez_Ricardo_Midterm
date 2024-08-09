using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    private AIState currentState;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform[] targets;
    [SerializeField] private int waypointIndex;
    [SerializeField] private float distanceToStop;

    private void Start()
    {

        ChangeAIState(new PatrolState(this));
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.OnStateRun();
        }

        /*
        if(agent.remainingDistance < distanceToStop)
        {
            waypointIndex++;
           if (waypointIndex >= targets.Length - 1)
            {
                waypointIndex = 0;
            }
            agent.SetDestination(targets[waypointIndex].position);
        }
        */
    }

    public void ChangeAIState(AIState state)
    {
        


        if (currentState != null)
        {
            currentState.OnStateExit();
        }

        currentState = state;

        currentState.OnStateEnter();
    }

    public Transform GetWaypoint(int index)
    {
        return targets[index];
    }

    public int TotalAmountOfWaypoints()
    {
        return targets.Length;
    }

   // public Transform[] GetPathArray()
    //{
     //   return targets;
    //}

    public NavMeshAgent GetAgent()
    {
        return agent;
    }

}
