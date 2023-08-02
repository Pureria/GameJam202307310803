using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOneLaser : EnemyState
{
    public EnemyOneLaser(EnemyController enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
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

        GameObject laser;
        Vector3 InitPosition = enemy.GetShotPosition(enemy.nowShotPattern.attackType[attackCount].position);
        laser = enemy.InstantiateAmmo(enemyData.enemyShotPrefabs.Laser2, Quaternion.identity, InitPosition);
        Vector3 pTran = GameManager.Instance.Player.transform.position;
        if (pTran != null)
        {
            Vector3 diff = (pTran - laser.transform.position).normalized;
            laser.transform.rotation = Quaternion.FromToRotation(Vector3.down, diff);
        }

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
