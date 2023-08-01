using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEnemyData", menuName = "Data/Enemy Data/Base Data")]
public class EnemyData : ScriptableObject
{
    [Header("Enemy HP")]
    public float EnemyHP = 100.0f;

    [Header("Enemy Invincible Time")]
    public float EnemyInvincibleTime = 0.1f;

    [Header("Enemy Shot Interval")]
    public float EnemyShotInterval = 1.5f;

    [Header("Enemy Shot Object")]
    [Tooltip("ammo1のオブジェクトとスピード")]
    public List<EnemyShotIntel> shotIntel = new List<EnemyShotIntel>();

    [System.Serializable]
    public class EnemyShotIntel
    {
        public GameObject shotObject;
        public float speed;
    }
}
