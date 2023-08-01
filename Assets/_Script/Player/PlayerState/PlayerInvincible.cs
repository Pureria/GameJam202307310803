using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvincible : PlayerState
{
    public PlayerInvincible(PlayerController player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    { }

    public override void Enter()
    {
        base.Enter();
        player.Damage?.SetCanDamage(false);
        player.Status?.Respawn();
        player.transform.position = playerData.SpawnPosition;
    }

    public override void Exit()
    {
        base.Exit();
        player.Damage.SetCanDamage(true);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (stateStartTime + playerData.InvincibleTime < Time.time)
            stateMachine.ChangeState(player.MoveState);

    }

    public override void PhycsUpdate()
    {
        base.PhycsUpdate();

        workspace = Camera.main.ScreenToWorldPoint(player.inputHandler.targetPosition);
        bool flg = false;
        if (Mathf.Abs(player.transform.position.x - workspace.x) < playerData.DeadZone &&
           Mathf.Abs(player.transform.position.y - workspace.y) < playerData.DeadZone)
            flg = true;

        if (!flg)
        {
            workspace = workspace - player.transform.position;
            workspace = new Vector3(workspace.x, workspace.y, 0).normalized;

            Vector3 checkDir = workspace * playerData.PlayerMoveSpeed;
            if (player.CheckFrameLeftPosition(checkDir.x + player.transform.position.x) &&
                player.CheckFrameRightPosition(checkDir.x + player.transform.position.x))
                player.Movement.SetVelocityX(new Vector3(workspace.x, 0, 0), playerData.PlayerMoveSpeed);

            if (player.CheckFrameTopPosition(checkDir.y + player.transform.position.y) &&
                player.CheckFrameBottomPosition(checkDir.y + player.transform.position.y))
                player.Movement.SetVelocityY(new Vector3(0, workspace.y, 0), playerData.PlayerMoveSpeed);
        }
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }
}
