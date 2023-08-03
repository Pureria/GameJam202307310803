using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRemoveFrame : EnemyState
{
    public EnemyRemoveFrame(EnemyController enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
    { }

    public override void Enter()
    {
        base.Enter();

        FramePosition.Instance.ResetScale();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        int attackCount = enemy.IdleState.attackCount;

        if (FramePosition.Instance.isChangedScale)
        {
            stateMachine.ChangeState(enemy.AfterRemoveFrameState);
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
