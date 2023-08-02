using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLazerStart : EnemyLazer
{
    public EnemyLazerStart(EnemyController enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
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

        if(FramePosition.Instance.isChangedScale)
        {
            //TODO::レーザー発射処理
            //仮処理
            GameObject lazer;
            Debug.Log("フレーム拡大終了");
            Vector3 InitPosition = enemy.GetShotPosition(enemy.nowShotPattern.attackType[attackCount].position);
            lazer = enemy.InstantiateAmmo(enemyData.shotIntel[1].shotObject, Quaternion.identity, InitPosition);
            lazer.transform.rotation = enemyData.shotIntel[1].shotObject.transform.rotation;
            lazerObj.Add(lazer);
            

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
