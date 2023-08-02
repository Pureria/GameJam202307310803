using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float MaxTime = 60.0f;
    [SerializeField]
    private TextMeshProUGUI GameTimeText;

    public static GameManager Instance;
    public GameObject Player { get; private set; }
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
        #if UNITY_EDITOR
        
        // デバッグ用にタイムを表示するやつ.
        isNowGame = true;
        GameStartTime = Time.time;
        GameTimeText.gameObject.SetActive(true);
        
        #else

        // 本番環境では非表示にする.
        isNowGame = false;
        GameTimeText.gameObject.SetActive(false);
        
        #endif
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
            }
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
