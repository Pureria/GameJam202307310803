using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    #region State Variables
    public EnemyStateMachine stateMachine;

    public EnemyIdle IdleState { get; private set; }
    public EnemyShot1 Shot1State { get; private set; }
    public EnemyShot2 Shot2State { get; private set; }
    public EnemyLazerStart LazerShotState { get; private set; }
    public EnemyLazerStop LazerShotStopState { get; private set; }
    public EnemyZoomFrame ZoomFrameState { get; private set; }
    public EnemyRemoveFrame RemoveFrameState { get; private set; }
    public EnemyOneLaser OneLaserState { get; private set; }
    public EnemyPlayerSearchShot PlayerSearchShotState { get; private set; }
    public EnemyDead DeadState { get; private set; }
    public EnemyEntry EntryState { get; private set; }
    #endregion

    #region Unity Variables
    public Animator _anim { get; private set; }
    public UnityEvent EntryEvent = new UnityEvent();
    public UnityEvent DeadEvent = new UnityEvent();
    #endregion

    #region Variables
    [SerializeField]
    private EnemyData enemyData;

    [SerializeField]
    private ShotPos shotPosition;

    public EnemyData.EnemyShotPattern nowShotPattern { get; private set; }

    public GameObject enemyHeart;

    private Core Core;
    public Damage Damage { get => damage ?? Core.GetCoreComponent(ref damage); }
    public Status Status { get => status ?? Core.GetCoreComponent(ref status); }

    private Damage damage;
    private Status status;
    private bool nowInvincible;
    private EnemyUIController uiController;
    private Vector3 workspace;
    #endregion

    #region Unity Callback Function
    private void Awake()
    {
        stateMachine = new EnemyStateMachine();
        IdleState = new EnemyIdle(this, stateMachine, enemyData, "idle");
        Shot1State = new EnemyShot1(this, stateMachine, enemyData, "idle");
        Shot2State = new EnemyShot2(this, stateMachine, enemyData, "idle");
        LazerShotState = new EnemyLazerStart(this, stateMachine, enemyData, "idle");
        LazerShotStopState = new EnemyLazerStop(this, stateMachine, enemyData, "idle");
        ZoomFrameState = new EnemyZoomFrame(this, stateMachine, enemyData, "idle");
        RemoveFrameState = new EnemyRemoveFrame(this, stateMachine, enemyData, "idle");
        OneLaserState = new EnemyOneLaser(this, stateMachine, enemyData, "idle");
        PlayerSearchShotState = new EnemyPlayerSearchShot(this, stateMachine, enemyData, "idle");
        DeadState = new EnemyDead(this, stateMachine, enemyData, "dead");
        EntryState = new EnemyEntry(this, stateMachine, enemyData, "entry");

        nowShotPattern = enemyData.shotPattern[0];
        IdleState.SetLockTime(enemyData.EnemyShotInterval);
    }

    private void Start()
    {
        GameManager.Instance?.SetEnemy(this.gameObject);
        _anim = GetComponent<Animator>();
        Core = GetComponentInChildren<Core>();
        uiController = GetComponent<EnemyUIController>();
        nowInvincible = false;

        Status?.Initialize(enemyData.EnemyHP);
        uiController.Initialize(enemyData.EnemyHP);
        stateMachine.Initialize(EntryState);
    }

    private void Update()
    {
        if(Damage.isDamage)
        {
            Damage?.UseDamageFlg();
            Damage?.SetCanDamage(false);
            nowInvincible = true;
        }
        else if(nowInvincible)
        {
            if(Damage.damageTime + enemyData.EnemyInvincibleTime<Time.time)
            {
                //無敵を解除
                Damage?.SetCanDamage(true);
                nowInvincible = false;
            }
        }

        stateMachine.LogicUpdate();
        uiController.UpdateHPSlider(Status.GetNowHP(),Damage.damageTime);

        float nowHp = Status.GetNowHP();
        if(nowHp <= 0 && stateMachine.currentState != DeadState)
        {
            EnemyLazer.DelLaserObj();
            FramePosition.Instance.ResetScale();
            stateMachine.ChangeState(DeadState);
        }

        //デバッグ用
        if(Input.GetKey(KeyCode.UpArrow))
        {
            Damage?.AddDamage(5.0f);
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

    public GameObject InstantiateAmmo(GameObject ammoObj, Quaternion rotation,Vector3 pos)
    {
        GameObject ret = null;
        ret = Instantiate(ammoObj, pos, rotation);
        return ret;
    }

    public void CheckAttackPattern()
    {
        EnemyData.EnemyShotPattern old = nowShotPattern;

        int cnt = enemyData.shotPattern.Count;
        float current = enemyData.EnemyHP / cnt;
        float nowHP = Status.GetNowHP();
        int dis = 0;
        for(int i = cnt - 1;i >= 0;i--)
        {
            if(nowHP > current * i)
            {
                nowShotPattern= enemyData.shotPattern[cnt - i - 1];
                break;
            }

            dis = cnt - i - 1;            
        }
        if (old != nowShotPattern) Debug.Log("パターン変更 : " + dis);
    }

    public bool GetNowInvincible() { return nowInvincible; }

    public Vector3 GetShotPosition(EnemyData.AttackPosition pos)
    {
        Vector3 ret = Vector3.zero;
        switch(pos)
        {
            case EnemyData.AttackPosition.PositionTop:
                ret = shotPosition.ShotPositionTop.position;
                break;

            case EnemyData.AttackPosition.PositionTopLeft:
                ret = shotPosition.ShotPositionTopLeft.position;
                break;

            case EnemyData.AttackPosition.PositionTopRight:
                ret = shotPosition.ShotPositionTopRight.position;
                break;

            case EnemyData.AttackPosition.PositionLeft:
                ret = shotPosition.ShotPositionLeft.position;
                break;

            case EnemyData.AttackPosition.PositionRight:
                ret = shotPosition.ShotPositionRight.position;
                break;

            case EnemyData.AttackPosition.PositionBottom:
                ret = shotPosition.ShotPositionBottom.position;
                break;

            case EnemyData.AttackPosition.PositionBottomLeft:
                ret = shotPosition.ShotPositionBottomLeft.position;
                break;

            case EnemyData.AttackPosition.PositionBottomRight:
                ret = shotPosition.ShotPositionBottomRight.position;
                break;
            default:
                ret = shotPosition.ShotPositionTop.position;
                break;
        }
        return ret;
    }
    #endregion
}

[System.Serializable]
public class ShotPos
{
    public Transform ShotPositionTop;
    public Transform ShotPositionTopLeft;
    public Transform ShotPositionTopRight;
    public Transform ShotPositionLeft;
    public Transform ShotPositionRight;
    public Transform ShotPositionBottom;
    public Transform ShotPositionBottomLeft;
    public Transform ShotPositionBottomRight;
}
