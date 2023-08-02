using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newCrystalData", menuName = "Data/Item Data/Crystal Base Data")]
public class CrystalData : ScriptableObject
{
    [Header("Crystal Data")]
    [Tooltip("�R�A�̈ړ����x")]
    public float CrystalSpeed = 0.02f;

    [Tooltip("�R�A�̃f�b�h�]�[��")]
    public float CrystalMoveDeadZone = 0.2f;

    [Tooltip("�t���b�V���̃C���^�[�o��")]
    public float CrystalFrashInterval = 0.2f;
}
