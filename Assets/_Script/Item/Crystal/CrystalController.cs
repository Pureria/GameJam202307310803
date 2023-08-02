using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalController : MonoBehaviour
{
    private Core Core;
    private Movement Movement { get => movement ?? Core.GetCoreComponent(ref movement); }
    private Movement movement;

    [SerializeField]
    private CrystalData crystalData;

    private Vector3 targetPosition;
    private Vector3 workspace;
    private void Start()
    {
        Core = GetComponentInChildren<Core>();
        targetPosition = moveRandomPosition();
    }

    private void Update()
    {
        workspace = targetPosition - transform.position;
        Movement?.SetVelocity(workspace.normalized, crystalData.CrystalSpeed);

        workspace = targetPosition - transform.position;
        if (Mathf.Abs(workspace.x) < crystalData.CrystalMoveDeadZone && Mathf.Abs(workspace.y) < crystalData.CrystalMoveDeadZone)
            targetPosition = moveRandomPosition();
    }

    private Vector3 moveRandomPosition()  // 目的地を生成、xとyのポジションをランダムに値を取得 
    {
        Vector3 randomPosi = new Vector3(Random.Range(FramePosition.LeftPosition, FramePosition.RightPosition), Random.Range(FramePosition.BottomPosition, FramePosition.TopPosition), 0);
        return randomPosi;
    }

    public CrystalData GetCrystalData() { return crystalData; }
}
