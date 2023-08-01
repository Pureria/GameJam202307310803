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

    [Header("Respawn Time"), Tooltip("���S�X�e�[�^�X�ɓ����Ă��烊�X�|�[������܂ł̎���")]
    //���S�A�j���[�V������菭�Ȃ����Ԃ��Ǝ��S�A�j���[�V�����I���シ�����X�|�[��
    public float RespawnTime = 1.5f;

    [Header("Respawn Invincible Time"),Tooltip("���X�|�[���X�e�[�^�X�̎���")]
    public float InvincibleTime = 1.5f;
}
