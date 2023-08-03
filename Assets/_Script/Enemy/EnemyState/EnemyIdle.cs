using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : EnemyState
{
    public int attackCount { get; protected set; }
    private float lockTime;
    private bool idleLock;
    private bool isSetNextState;
    private EnemyState nextState;

    public EnemyIdle(EnemyController enemy,EnemyStateMachine stateMachine,EnemyData enemyData,string animBoolName):base(enemy,stateMachine,enemyData,animBoolName)
    {
        isSetNextState = false;
        attackCount = 0;
        nextState = this;
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

        if (this.isSetNextState)
        {
            this.isSetNextState = false;
            stateMachine.ChangeState(this.nextState);
        }

        if (attackCount >= enemy.nowShotPattern.attackType.Count)
        {
            enemy.CheckAttackPattern();
            attackCount = 0;
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

            case EnemyData.AttackType.LaserStart:
                stateMachine.ChangeState(enemy.LazerShotState);
                    break;

            case EnemyData.AttackType.LaserStop:
                stateMachine.ChangeState(enemy.LazerShotStopState);
                break;

            case EnemyData.AttackType.ZoomFrame:
                stateMachine.ChangeState(enemy.BeforeZoomFrameState);
                break;

            case EnemyData.AttackType.RemoveFrame:
                stateMachine.ChangeState(enemy.BeforeRemoveFrameState);
                break;

            case EnemyData.AttackType.OneShotLaser:
                stateMachine.ChangeState(enemy.OneLaserState);
                break;

            case EnemyData.AttackType.PlayerSearchShot:
                stateMachine.ChangeState(enemy.PlayerSearchShotState);
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
        this.isSetNextState = true;
        this.nextState = nextState;
    }

    public void AddAtackCount()
    {
        attackCount += 1;
    }
}
