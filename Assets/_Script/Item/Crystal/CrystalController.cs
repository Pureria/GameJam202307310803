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
        //TargetPositionのチェック
        if (!CheckFrameLeftPosition(targetPosition.x))
        {
            targetPosition = new Vector3(FramePosition.LeftPosition, targetPosition.y, 0.0f);
        }
        else if (!CheckFrameRightPosition(targetPosition.x))
        {
            targetPosition = new Vector3(FramePosition.RightPosition, targetPosition.y, 0.0f);
        }

        if (!CheckFrameTopPosition(targetPosition.y))
        {
            targetPosition = new Vector3(targetPosition.x, FramePosition.TopPosition, 0.0f);
        }
        else if (!CheckFrameBottomPosition(targetPosition.y))
        {
            targetPosition = new Vector3(targetPosition.x, FramePosition.BottomPosition, 0.0f);
        }

        //Transform.Positionのチェック
        if (!CheckFrameLeftPosition(transform.position.x))
        {
            transform.position = new Vector3(FramePosition.LeftPosition, transform.position.y, 0.0f);
        }
        else if (!CheckFrameRightPosition(transform.position.x))
        {
            transform.position = new Vector3(FramePosition.RightPosition, transform.position.y, 0.0f);
        }

        if (!CheckFrameTopPosition(transform.position.y))
        {
            transform.position = new Vector3(transform.position.x, FramePosition.TopPosition, 0.0f);
        }
        else if (!CheckFrameBottomPosition(transform.position.y))
        {
            transform.position = new Vector3(transform.position.x, FramePosition.BottomPosition, 0.0f);
        }
    }

    private void FixedUpdate()
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

    public bool CheckFrameLeftPosition(float checkPositionLeft)
    {
        bool ret = false;
        if (checkPositionLeft > FramePosition.LeftPosition)
            ret = true;

        return ret;
    }

    public bool CheckFrameRightPosition(float checkPositionRight)
    {
        bool ret = false;
        if (checkPositionRight < FramePosition.RightPosition)
            ret = true;

        return ret;
    }

    public bool CheckFrameTopPosition(float checkPositionTop)
    {
        bool ret = false;
        if (checkPositionTop < FramePosition.TopPosition)
            ret = true;

        return ret;
    }

    public bool CheckFrameBottomPosition(float checkPositionBottom)
    {
        bool ret = false;
        if (checkPositionBottom > FramePosition.BottomPosition)
            ret = true;

        return ret;
    }
}
