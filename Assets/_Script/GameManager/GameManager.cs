using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

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

    //初期化処理
    private void GameInitialize()
    {
        Player.gameObject.SetActive(true);
        Player.Initialize();
        this.gameStart.Invoke();

        BossManager.Instance?.Initialize();
        BossManager.Instance?.InstantiateNextBoss();
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
        GameInitialize();
    }

    public void GameClear()
    {
        //ゲームクリア時処理
        gameClearEvent.Invoke();
        GameEnd();
    }

    public void GameOver()
    {
        //ゲームオーバー時処理
        gameOverEvent.Invoke();
        GameEnd();
    }

    public void Restart()
    {
        //リスタート処理
        isNowGame = true;
        GameRestart();
    }
    #endregion
}
