using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerController player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;
    protected bool isAnimationFinished;
    protected Vector3 workspace;

    private string animBoolName;

    public PlayerState(PlayerController player,PlayerStateMachine stateMachine,PlayerData playerData,string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        isAnimationFinished = false;
        player._anim.SetBool(animBoolName, true);
    }

    public virtual void Exit()
    {
        player._anim.SetBool(animBoolName, false);
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
