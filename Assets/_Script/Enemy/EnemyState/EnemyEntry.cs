using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntry : EnemyState
{
    public EnemyEntry(EnemyController enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
    { }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationFinished)
        {
            enemy.EntryEvent.Invoke();
            enemy.enemyHeart = enemy.InstantiateAmmo(enemyData.EnemyHeart, Quaternion.identity, enemyData.enemyHeartPosition);
            stateMachine.ChangeState(enemy.IdleState);
        }
    }

    public override void PhycsUpdate()
    {
        base.PhycsUpdate();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }
}
