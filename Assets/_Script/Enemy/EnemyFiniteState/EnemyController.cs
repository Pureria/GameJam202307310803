using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region State Variables
    public EnemyStateMachine stateMachine;

    public EnemyIdle IdleState { get; private set; }
    public EnemyShot1 Shot1State { get; private set; }
    public EnemyShot2 Shot2State { get; private set; }
    #endregion

    #region Unity Variables
    public Animator _anim { get; private set; }
    #endregion

    #region Variables
    [SerializeField]
    private bool DebugShot = false;

    [SerializeField]
    private EnemyData enemyData;

    public List<Transform> ShotPosition = new List<Transform>();

    public EnemyData.EnemyShotPattern nowShotPattern { get; private set; }

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
        stateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        if(DebugShot)
        {
            DebugShot = false;

            workspace = GameManager.Instance.Player.transform.position - this.transform.position;
            GameObject shot = Instantiate(enemyData.shotIntel[0].shotObject, transform.position, Quaternion.identity);
            shot.GetComponent<EnemyShotMove>().SetDirection(workspace.normalized, enemyData.shotIntel[0].speed);
        }

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
    public GameObject InstantiateAmmo(GameObject ammoObj, Quaternion rotation)
    {
        GameObject ret = null;
        ret = Instantiate(ammoObj, ShotPosition[0].position, rotation);
        return ret;
    }

    public void CheckAttackPattern()
    {
        int cnt = enemyData.shotPattern.Count - 1;
        float current = enemyData.EnemyHP / cnt;
        int num = (int)(Status.GetNowHP() / current);
        EnemyData.EnemyShotPattern old = nowShotPattern;
        nowShotPattern = enemyData.shotPattern[cnt - num];

        if(old != nowShotPattern)
        {
            Debug.Log("パターン変更");
        }
    }

    public bool GetNowInvincible() { return nowInvincible; }
    #endregion
}
