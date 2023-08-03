using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : EnemyState
{
    public EnemyDead(EnemyController enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
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

        if(isAnimationFinished)
        {
            enemy.DeadEvent.Invoke();
            enemy.DeadAction?.Invoke();
            enemy.GameEnd();

            var player = GameManager.Instance.Player;
            var health = player.GetComponent<GJ.Health.HealthTime>();
            health.Heal();
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
