using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLazer : EnemyState
{
    protected static List<GameObject> lazerObj = new List<GameObject>();

    public EnemyLazer(EnemyController enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
    { }
}
