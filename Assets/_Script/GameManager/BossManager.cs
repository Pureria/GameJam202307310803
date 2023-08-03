using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public static BossManager Instance { get; private set; }

    [Header("ボスの形態")]
    [SerializeField]
    private List<GameObject> BossPrefab = new List<GameObject>();

    private int nowBossCount;

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
        GameObject boss = Instantiate(BossPrefab[nowBossCount], Vector3.zero, Quaternion.identity);
        nowBossCount++;

        if (nowBossCount < BossPrefab.Count)
            BossInitialize(boss);
        else
            LastBossInitialize(boss);
    }

    public void BossInitialize(GameObject boss)
    {
        EnemyController ec;
        ec = boss.GetComponent<EnemyController>();
        if (ec != null)
            ec.DeadAction = () =>
            {
               InstantiateNextBoss();
            };
    }
    public void LastBossInitialize(GameObject boss)
    {
        //TODO::最後のボスのDeadEventを設定
    }
}
