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
}
