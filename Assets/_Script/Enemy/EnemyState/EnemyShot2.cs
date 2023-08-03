using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot2 : EnemyState
{
    public EnemyShot2(EnemyController enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
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
        GameObject shot;
        int attackCount = enemy.IdleState.attackCount;
        Vector3 InstPosition = enemy.GetShotPosition(enemy.nowShotPattern.attackType[attackCount].position);

        workspace = GameManager.Instance.Player.transform.position - InstPosition;
        workspace.x = workspace.x + enemyData.EnemyShot2AddX;
        shot = enemy.Instantiate(enemyData.enemyShotPrefabs.Shot1, Quaternion.identity, InstPosition);
        shot.GetComponent<EnemyShotMove>().SetDirection(workspace.normalized, enemyData.enemyShotPrefabs.shot1Speed);

        for (int i = 1; i <= enemyData.EnemyShot2Count; i++)
        {
            workspace = (GameManager.Instance.Player.transform.position - InstPosition);
            workspace.x = workspace.x + (1.5f * i) + enemyData.EnemyShot2AddX;
            shot = enemy.Instantiate(enemyData.enemyShotPrefabs.Shot1, Quaternion.identity, InstPosition);
            shot.GetComponent<EnemyShotMove>().SetDirection(workspace.normalized, enemyData.enemyShotPrefabs.shot1Speed);

            workspace = (GameManager.Instance.Player.transform.position - InstPosition);
            workspace.x = workspace.x - (1.5f * i) + enemyData.EnemyShot2AddX;
            shot = enemy.Instantiate(enemyData.enemyShotPrefabs.Shot1, Quaternion.identity, InstPosition);
            shot.GetComponent<EnemyShotMove>().SetDirection(workspace.normalized, enemyData.enemyShotPrefabs.shot1Speed);
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
