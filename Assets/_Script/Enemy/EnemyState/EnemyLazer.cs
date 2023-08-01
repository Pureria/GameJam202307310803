using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLazer : EnemyState
{
    protected static GameObject lazerObj;

    public EnemyLazer(EnemyController enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
    { }
}
