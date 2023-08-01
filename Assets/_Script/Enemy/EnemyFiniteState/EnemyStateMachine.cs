using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine
{
    public EnemyState currentState { get; private set; }
    public EnemyState oldCurrentState { get; private set; }

    public void Initialize(EnemyState initState)
    {
        currentState = initState;
        oldCurrentState = initState;
        currentState.Enter();
    }

    public void ChangeState(EnemyState changeState)
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
