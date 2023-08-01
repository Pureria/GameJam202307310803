using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Player Speed")]
    public float PlayerMoveSpeed = 0.2f;

    [Header("Mouse Dead Zone")]
    public float DeadZone = 0.2f;

    [Header("Spawn Position")]
    public Vector2 SpawnPosition = Vector2.zero;

    [Header("Respawn Time"), Tooltip("死亡ステータスに入ってからリスポーンするまでの時間")]
    //死亡アニメーションより少ない時間だと死亡アニメーション終了後すぐリスポーン
    public float RespawnTime = 1.5f;

    [Header("Respawn Invincible Time"),Tooltip("リスポーンステータスの時間")]
    public float InvincibleTime = 1.5f;
}
