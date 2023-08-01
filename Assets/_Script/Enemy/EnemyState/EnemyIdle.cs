using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : EnemyState
{
    private float lockTime;
    private bool idleLock;

    public EnemyIdle(EnemyController enemy,EnemyStateMachine stateMachine,EnemyData enemyData,string animBoolName):base(enemy,stateMachine,enemyData,animBoolName)
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

        if(idleLock)
        {
            if (lockTime < Time.time)
                idleLock = false;
            return;
        }

        //各ステータスに移行
    }

    public override void PhycsUpdate()
    {
        base.PhycsUpdate();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public void SetLockTime(float lockTime)
    {
        this.lockTime = Time.time + lockTime;
        idleLock = true;
    }
}
