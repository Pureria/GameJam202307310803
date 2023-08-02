using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected EnemyController enemy;
    protected EnemyStateMachine stateMachine;
    protected EnemyData enemyData;

    protected bool isAnimationFinished;

    protected Vector3 workspace;

    private string animBoolName;

    //protected int memoAttackCount; 

    public EnemyState(EnemyController enemy,EnemyStateMachine stateMachine,EnemyData enemyData,string animBoolName)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
        this.enemyData = enemyData;
        this.animBoolName = animBoolName;

        //this.memoAttackCount = 0;
    }

    public virtual void Enter()
    {
        isAnimationFinished = false;
        enemy._anim.SetBool(animBoolName, true);
        //this.memoAttackCount = enemy.IdleState.attackCount;
    }

    public virtual void Exit()
    {
        enemy._anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {
        
    }

    public virtual void PhycsUpdate()
    {

    }

    public virtual void AnimationTrigger()
    {

    }

    public void AnimationFinishedTrigger() => isAnimationFinished = true;
}
