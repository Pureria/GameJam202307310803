using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using GJ.Health;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool debugNowGame;

    [SerializeField]
    private float MaxTime = 60.0f;
    [SerializeField]
    private TextMeshProUGUI GameTimeText;
    [SerializeField] UnityEvent gameStart;
    [SerializeField] UnityEvent gameClearEvent;
    [SerializeField] UnityEvent gameOverEvent;
    [SerializeField] HealthTime playerHealth;

    public static GameManager Instance;
    public PlayerController Player;
    public GameObject Enemy { get; private set; }

    public bool isNowGame { get; private set; }
    public float GameTime { get; private set; }
    public float GameStartTime { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            GameObject.Destroy(this);      
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
            //GameTime = MaxTime - (Time.time - GameStartTime);
            GameTimeText.text = playerHealth.Health.ToString("n2");

            /*
            if(GameTime < 0)
            {
                //ゲームオーバー処理
                isNowGame = false;
                debugNowGame = false;                
            }
            */
        }
    }

    //初期化処理
    private void GameInitialize()
    {
        Player.gameObject.SetActive(true);
        Player.Initialize();
        this.gameStart.Invoke();

        BossManager.Instance?.Initialize();
        BossManager.Instance?.InstantiateNextBoss();

        FramePosition.Instance.ShowFrame();
    }

    private void GameRestart()
    {
        //TODO::リスタート用の処理
        GameInitialize();
    }

    private void GameEnd()
    {
        Player.gameObject.SetActive(false);
        BossManager.Instance?.GameEnd();
        FramePosition.Instance.HideFrame();
    }

    #region Set Function

    public void SetEnemy(GameObject enemy)
    {
        this.Enemy = enemy;
    }

    public float GetNowTime() { return GameTime; }

    public void GameStart()
    {
        //ゲームスタート処理
        isNowGame = true;
        Debug.Log("ゲームスタート");
        GameInitialize();
    }

    public void GameClear()
    {
        //ゲームクリア時処理
        gameClearEvent.Invoke();
        Debug.Log("ゲームクリア");
        GameEnd();
    }

    public void GameOver()
    {
        //ゲームオーバー時処理
        gameOverEvent.Invoke();
        Debug.Log("ゲームオーバー");
        GameEnd();
    }

    public void Restart()
    {
        //リスタート処理
        isNowGame = true;
        Debug.Log("リスタート");
        GameRestart();
    }
    #endregion
}
