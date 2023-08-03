using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZoomFrame : EnemyState
{
    public EnemyZoomFrame(EnemyController enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
    { }

    public override void Enter()
    {
        base.Enter();

        FramePosition.Instance.ChangeScale(enemyData.EnemyFrameScale.x, enemyData.EnemyFrameScale.y);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        int attackCount = enemy.IdleState.attackCount;

        if (FramePosition.Instance.isChangedScale && isAnimationFinished)
        {
            stateMachine.ChangeState(enemy.AfterZoomFrameState);
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
