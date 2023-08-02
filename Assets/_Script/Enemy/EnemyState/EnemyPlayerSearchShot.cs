using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerSearchShot : EnemyState
{
    public EnemyPlayerSearchShot(EnemyController enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
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
        int attackCount = enemy.IdleState.attackCount;

        workspace = GameManager.Instance.Player.transform.position;
        GameObject shot = enemy.InstantiateAmmo(enemyData.enemyShotPrefabs.SearchShot, Quaternion.identity, workspace);

        enemy.IdleState.SetLockTime(enemy.nowShotPattern.attackType[attackCount].nextStateInterval);
        enemy.IdleState.AddAtackCount();
        stateMachine.ChangeState(enemy.IdleState);
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
