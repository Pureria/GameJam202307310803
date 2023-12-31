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

    [Header("Enemy Heart")]
    public GameObject EnemyHeart;
    public Vector3 enemyHeartPosition;
    public bool SpawnEnemyHeart = true;
    public float RunAwayTime = 30.0f;

    [Header("Enemy Shot Object")]
    [Tooltip("ShotPrefabsέθ")]
    public EnemyShotPrefabs enemyShotPrefabs = new EnemyShotPrefabs();

    [Header("Enemy Shot")]
    [Tooltip("Shot1ΜΆEe[v")]
    public int EnemyShot1Count = 3;

    [Tooltip("Shot2ΜΆEe[v")]
    public int EnemyShot2Count = 2;

    [Tooltip("Shot2ΜeπΈη·£")]
    public float EnemyShot2AddX = 0.8f;

    [Tooltip("[U[ΛoΜμΝΝΜXP[")]
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
        PositionTopLeft,
        PositionTopRight,
        PositionLeft,
        PositionRight,
        PositionBottom,
        PositionBottomLeft,
        PositionBottomRight,
        PositionCount
    }
}
