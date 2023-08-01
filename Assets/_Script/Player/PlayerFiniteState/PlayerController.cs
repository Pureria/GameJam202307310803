using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region State Varibles
    [SerializeField]
    private PlayerData playerData;
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerInputHandler inputHandler { get; private set; }

    public PlayerMove MoveState { get; private set; }
    public PlayerDead DeadState { get; private set; }
    public PlayerInvincible InvincibleState { get; private set; }
    #endregion

    #region Variables
    public Animator _anim { get; private set; }

    public Core Core { get; private set; }
    public Movement Movement { get => movement ?? Core.GetCoreComponent(ref movement); }
    private Movement movement;

    public Status Status { get => status ?? Core.GetCoreComponent(ref status); }
    private Status status;

    public Damage Damage { get => damage ?? Core.GetCoreComponent(ref damage); }
    private Damage damage;
    #endregion

    #region Unity Callback Function
    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
        MoveState = new PlayerMove(this, stateMachine, playerData, "move");
        DeadState = new PlayerDead(this, stateMachine, playerData, "dead");
        InvincibleState = new PlayerInvincible(this, stateMachine, playerData, "invincible");

    }

    private void Start()
    {
        GameManager.Instance?.SetPlayer(this.gameObject);
        _anim = GetComponent<Animator>();
        Core = GetComponentInChildren<Core>();
        inputHandler = GetComponent<PlayerInputHandler>();

        Status?.Initialize(1.0f);
        //stateMachine‚Ì‰Šú‰»ˆ—
        stateMachine.Initialize(MoveState);
    }

    private void Update()
    {
        stateMachine.LogicUpdate();

        if(!CheckFrameLeftPosition(transform.position.x))
        {
            transform.position = new Vector3(FramePosition.LeftPosition, transform.position.y, 0.0f);
        }
        else if(!CheckFrameRightPosition(transform.position.x))
        {
            transform.position = new Vector3(FramePosition.RightPosition, transform.position.y, 0.0f);
        }

        if (!CheckFrameTopPosition(transform.position.y))
        {
            transform.position = new Vector3(transform.position.x, FramePosition.TopPosition, 0.0f);
        }
        else if(!CheckFrameBottomPosition(transform.position.y))
        {
            transform.position = new Vector3(transform.position.x, FramePosition.BottomPosition, 0.0f);
        }

        //TODO::ƒ_ƒ[ƒW”»’è
        if(Status.isDead && stateMachine.currentState != DeadState)
        {
            stateMachine.ChangeState(DeadState);
        }
    }

    private void FixedUpdate()
    {
        stateMachine.PhycsUpdate();
    }
    #endregion

    #region Other Function
    public void AnimationFinishedTrigger() { stateMachine.currentState.AnimationFinishedTrigger(); }
    public void AnimationTrigger() { stateMachine.currentState.AnimationTrigger(); }

    public bool CheckFrameLeftPosition(float checkPositionLeft)
    {
        bool ret = false;
        if (checkPositionLeft > FramePosition.LeftPosition)
            ret = true;

        return ret;
    }

    public bool CheckFrameRightPosition(float checkPositionRight)
    {
        bool ret = false;
        if (checkPositionRight < FramePosition.RightPosition)
            ret = true;

        return ret;
    }

    public bool CheckFrameTopPosition(float checkPositionTop)
    {
        bool ret = false;
        if (checkPositionTop < FramePosition.TopPosition)
            ret = true;

        return ret;
    }

    public bool CheckFrameBottomPosition(float checkPositionBottom)
    {
        bool ret = false;
        if (checkPositionBottom > FramePosition.BottomPosition)
            ret = true;

        return ret;
    }
    #endregion
}
