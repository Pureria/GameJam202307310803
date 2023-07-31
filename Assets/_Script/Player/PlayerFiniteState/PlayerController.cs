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
    #endregion

    #region Variables
    public Animator _anim { get; private set; }

    public Core Core { get; private set; }
    public Movement Movement { get => movement ?? Core.GetCoreComponent(ref movement); }
    private Movement movement;
    #endregion

    #region Unity Callback Function
    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
        MoveState = new PlayerMove(this, stateMachine, playerData, "move");
    }

    private void Start()
    {
        _anim = GetComponent<Animator>();
        Core = GetComponentInChildren<Core>();
        inputHandler = GetComponent<PlayerInputHandler>();

        //stateMachine‚Ì‰Šú‰»ˆ—
        stateMachine.Initialize(MoveState);
    }

    private void Update()
    {
        stateMachine.LogicUpdate();
    }

    private void FixedUpdate()
    {
        stateMachine.PhycsUpdate();
    }
    #endregion

    #region Other Function
    public void AnimationFinishedTrigger() { stateMachine.currentState.AnimationFinishedTrigger(); }
    public void AnimationTrigger() { stateMachine.currentState.AnimationTrigger(); }
    #endregion
}
