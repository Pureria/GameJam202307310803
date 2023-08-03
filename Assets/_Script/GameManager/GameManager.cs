using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using GJ;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool debugNowGame;

    [SerializeField]
    private float MaxTime = 60.0f;
    [SerializeField]
    private TextMeshProUGUI GameTimeText;

    // TODO: GameStart() が追加され次第使う.
    private Timer timeAttackTimer;
    private UnityEvent onGameClear = new UnityEvent();
    public UnityEvent OnGameClear { get { return this.onGameClear; } }
    // --------

    public static GameManager Instance;
    public GameObject Player;
    public GameObject Enemy { get; private set; }

    public bool isNowGame { get; private set; }
    public float GameTime { get; private set; }
    public float GameStartTime { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else GameObject.Destroy(this);
    }

    private void Start()
    {
        InitializeData();
    }

    void InitializeData ()
    {
        isNowGame = false;
    }

    private void Update()
    {
        
        if(isNowGame)
        {
            GameTime = MaxTime - (Time.time - GameStartTime);
            GameTimeText.text = GameTime.ToString("n2");

            if(GameTime < 0)
            {
                //ゲームオーバー処理
                isNowGame = false;
                debugNowGame = false;                
            }
        }

        //TODO::デバッグ用
        if(debugNowGame && !isNowGame)
        {
            isNowGame = true;
            GameStartTime = Time.time;
            GameTimeText.enabled = true;
        }
        else if(!debugNowGame && isNowGame)
        {
            isNowGame = false;
            GameTimeText.enabled = false;
        }
    }

    #region Set Function
    public void SetPlayer(GameObject player)
    {
        this.Player = player;
    }

    public void SetEnemy(GameObject enemy)
    {
        this.Enemy = enemy;
    }

    public float GetNowTime() { return GameTime; }
    #endregion
}
