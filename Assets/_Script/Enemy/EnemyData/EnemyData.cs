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
    [Tooltip("ammo1�̃I�u�W�F�N�g�ƃX�s�[�h")]
    public List<EnemyShotIntel> shotIntel = new List<EnemyShotIntel>();

    [Tooltip("Shot1�̍��E�e���[�v��")]
    public int EnemyShot1Count = 3;

    [Tooltip("Shot2�̍��E�e���[�v��")]
    public int EnemyShot2Count = 2;

    [Tooltip("Shot2�̒e�����炷����")]
    public float EnemyShot2AddX = 0.8f;

    [Header("Enemy Attack Pattern")]
    public List<EnemyShotPattern> shotPattern = new List<EnemyShotPattern>();

    [System.Serializable]
    public class EnemyShotIntel
    {
        public GameObject shotObject;
        public float speed;
    }

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

    public enum AttackType
    {
        Attack1,
        Attack2,
        LazerStart,
        LazerStop,
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
