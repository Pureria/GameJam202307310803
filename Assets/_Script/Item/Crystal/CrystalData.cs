using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newCrystalData", menuName = "Data/Item Data/Crystal Base Data")]
public class CrystalData : ScriptableObject
{
    [Header("Crystal Data")]
    [Tooltip("コアの移動速度")]
    public float CrystalSpeed = 0.02f;

    [Tooltip("コアのデッドゾーン")]
    public float CrystalMoveDeadZone = 0.2f;

    [Tooltip("フラッシュのインターバル")]
    public float CrystalFrashInterval = 0.2f;
}
