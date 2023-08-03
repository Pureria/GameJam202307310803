using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLazerStop : EnemyLazer
{
    public EnemyLazerStop(EnemyController enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
    { }

    public override void Enter()
    {
        base.Enter();

        //FramePosition.Instance.ResetScale();
        foreach(GameObject lazer in lazerObj)
        {
            GameObject.Destroy(lazer);
        }
        lazerObj.Clear();
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
            //TODO::���[�U�[���ˏ���
            //������
            Debug.Log("�t���[�����Z�b�g�I��");


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
