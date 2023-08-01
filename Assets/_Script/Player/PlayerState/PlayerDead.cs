using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : PlayerState
{
    public PlayerDead(PlayerController player,PlayerStateMachine stateMachine,PlayerData playerData,string animBoolName):base(player,stateMachine,playerData,animBoolName)
    { }

    public override void Enter()
    {
        base.Enter();
        player.Damage.SetCanDamage(false);
    }

    public override void Exit()
    {
        base.Exit();
        player.Damage.SetCanDamage(true);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //���S�A�j���[�V�����I��
        if(isAnimationFinished)
        {
            //���X�|�[���X�e�[�^�X�Ɉڍs
            if(stateStartTime + playerData.RespawnTime < Time.time)
            {
                stateMachine.ChangeState(player.InvincibleState);
            }
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
