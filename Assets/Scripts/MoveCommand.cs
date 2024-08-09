using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveCommand : Command
{
    private NavMeshAgent agentToCommand;
    private Vector3 desination;

    public override void ExecuteCommand()
    {
        agentToCommand.SetDestination(desination);
    }


    public override bool IsCompleted()
    {
        return agentToCommand.remainingDistance < 0.2f;
    }

    public MoveCommand(NavMeshAgent agent, Vector3 targetPosition)
    {
        agentToCommand = agent;
        desination = targetPosition;
    }
}
