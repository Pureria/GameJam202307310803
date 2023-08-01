using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region State Variables
    public EnemyStateMachine stateMachine;

    public EnemyIdle IdleState { get; private set; }
    #endregion

    #region Unity Variables
    public Animator _anim { get; private set; }
    #endregion

    #region Variables
    [SerializeField]
    private bool DebugShot = false;

    [SerializeField]
    private EnemyData enemyData;

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
                //–³“G‚ð‰ðœ
                Damage?.SetCanDamage(true);
                nowInvincible = false;
            }
        }

        uiController.UpdateHPSlider(Status.GetNowHP());
    }

    private void FixedUpdate()
    {
        
    }
    #endregion

    #region Other Function
    #endregion
}
