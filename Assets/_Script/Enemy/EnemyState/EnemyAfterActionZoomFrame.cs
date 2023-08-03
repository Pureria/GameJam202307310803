using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAfterActionZoomFrame : EnemyState
{
    public EnemyAfterActionZoomFrame(EnemyController enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
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
            int attackCount = enemy.IdleState.attackCount;
            enemy.IdleState.SetLockTime(enemy.nowShotPattern.attackType[attackCount].nextStateInterval);
            enemy.IdleState.AddAtackCount();
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
