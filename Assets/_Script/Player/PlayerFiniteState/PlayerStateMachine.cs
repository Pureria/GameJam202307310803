using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    public PlayerState currentState { get; private set; }
    public PlayerState oldCurrentState { get; private set; }

    public void Initialize(PlayerState initState)
    {
        currentState = initState;
        oldCurrentState = initState;
        currentState.Enter();
    }

    public void ChangeState(PlayerState changeState)
    {
        currentState.Exit();
        oldCurrentState = currentState;
        currentState = changeState;
        currentState.Enter();
    }

    public void LogicUpdate()
    {
        currentState.LogicUpdate();
    }

    public void PhycsUpdate()
    {
        currentState.PhycsUpdate();
    }
}
