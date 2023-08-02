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
    [Tooltip("ShotPrefabs設定")]
    public EnemyShotPrefabs enemyShotPrefabs = new EnemyShotPrefabs();

    [Header("Enemy Shot")]
    [Tooltip("Shot1の左右弾ループ数")]
    public int EnemyShot1Count = 3;

    [Tooltip("Shot2の左右弾ループ数")]
    public int EnemyShot2Count = 2;

    [Tooltip("Shot2の弾をずらす距離")]
    public float EnemyShot2AddX = 0.8f;

    [Tooltip("レーザー射出時の操作範囲のスケール")]
    public Vector3 EnemyFrameScale = Vector3.zero;

    [Header("Enemy Attack Pattern")]
    public List<EnemyShotPattern> shotPattern = new List<EnemyShotPattern>();

    [System.Serializable]
    public class EnemyShotPattern
    {
        public List<EnemyShotModel> attackType = new List<EnemyShotModel>();
    }

    [System.Serializable]
    public class EnemyShotModel
    {
        public AttackType type;
        public AttackPosition position;
        public float nextStateInterval = 1.0f;
    }

    [System.Serializable]
    public class EnemyShotPrefabs
    {
        public GameObject Shot1;
        public float shot1Speed;

        public GameObject Laser1;
        public GameObject Laser2;

        public GameObject SearchShot;
    }

    public enum AttackType
    {
        Attack1,
        Attack2,
        LaserStart,
        LaserStop,
        OneShotLaser,
        ZoomFrame,
        RemoveFrame,
        PlayerSearchShot,
        AttackCount
    }

    public enum AttackPosition
    {
        PositionTop,
        PositionLeft,
        PositionRight,
        PositionCount
    }
}
