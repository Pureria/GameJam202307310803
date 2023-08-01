using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : EnemyState
{
    private float lockTime;
    private bool idleLock;
    private bool isSetNextState;
    private EnemyState nextState;

    public int attackCount { get; private set; }
    public EnemyIdle(EnemyController enemy,EnemyStateMachine stateMachine,EnemyData enemyData,string animBoolName):base(enemy,stateMachine,enemyData,animBoolName)
    {
        isSetNextState = false;
        attackCount = 0;
    }

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
        /*
        if(isSetNextState)
        {
            isSetNextState = false;
            stateMachine.ChangeState(nextState);
        }
        else
            stateMachine.ChangeState(enemy.Shot1State);
        */

        if (attackCount >= enemy.nowShotPattern.attackType.Count)
        {
            attackCount = 0;
            enemy.CheckAttackPattern();
        }
        EnemyData.AttackType nextState = enemy.nowShotPattern.attackType[attackCount].type;
        switch(nextState)
        {
            case EnemyData.AttackType.Attack1:
                stateMachine.ChangeState(enemy.Shot1State);
                break;

            case EnemyData.AttackType.Attack2:
                stateMachine.ChangeState(enemy.Shot2State);
                break;

            default:
                break;
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

    public void SetLockTime(float lockTime)
    {
        this.lockTime = Time.time + lockTime;
        idleLock = true;
    }

    public void SetNextState(EnemyState nextState)
    {
        isSetNextState = true;
        this.nextState = nextState;
    }

    public void AddAtackCount() => attackCount++;
}
