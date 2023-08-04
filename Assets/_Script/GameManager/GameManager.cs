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
                //�Q�[���I�[�o�[����
                isNowGame = false;
                debugNowGame = false;                
            }
            */
        }
    }

    //����������
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
        //TODO::���X�^�[�g�p�̏���
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
        //�Q�[���X�^�[�g����
        isNowGame = true;
        Debug.Log("�Q�[���X�^�[�g");
        GameInitialize();
    }

    public void GameClear()
    {
        //�Q�[���N���A������
        gameClearEvent.Invoke();
        Debug.Log("�Q�[���N���A");
        GameEnd();
    }

    public void GameOver()
    {
        //�Q�[���I�[�o�[������
        gameOverEvent.Invoke();
        Debug.Log("�Q�[���I�[�o�[");
        GameEnd();
    }

    public void Restart()
    {
        //���X�^�[�g����
        isNowGame = true;
        Debug.Log("���X�^�[�g");
        GameRestart();
    }
    #endregion
}
