using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public static BossManager Instance { get; private set; }

    [Header("ボスの形態")]
    [SerializeField]
    private List<GameObject> BossPrefab = new List<GameObject>();

    private GameObject nowBoss;

    
    private int nowBossCount;

    public int NowBossCount
    {
        get { return this.nowBossCount; }
    }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Initialize();
        }
        else
            GameObject.Destroy(this.gameObject);
    }

    //TODO::ゲームを開始したらInitialize関数を呼ぶ
    public void Initialize()
    {
        nowBossCount = 0;
    }

    public void InstantiateNextBoss()
    {
        if (nowBossCount > BossPrefab.Count) return;
        nowBoss = Instantiate(BossPrefab[nowBossCount], Vector3.zero, Quaternion.identity);
        nowBossCount++;

        if (nowBossCount < BossPrefab.Count)
            BossInitialize(nowBoss);
        else
            LastBossInitialize(nowBoss);
    }

    public void GameEnd()
    {
        EnemyController ec;
        ec = nowBoss.GetComponent<EnemyController>();
        if (ec == null) return;
        ec.GameEnd();
    }

    private void BossInitialize(GameObject boss)
    {
        EnemyController ec;
        ec = boss.GetComponent<EnemyController>();
        if (ec != null)
            ec.DeadAction = () =>
            {
               InstantiateNextBoss();
            };
    }
    private void LastBossInitialize(GameObject boss)
    {
        EnemyController ec;
        ec = boss.GetComponent<EnemyController>();
        if (ec != null)
            ec.DeadAction = () =>
            {
                GameManager.Instance?.GameClear();
            };
    }
}
