using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : CoreComponent
{
    Vector3 currentPosition;
    private Transform _Tran;
    private bool canMove;

    protected override void Start()
    {
        base.Start();
        _Tran = transform.root.transform;
        canMove = true;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        currentPosition = transform.root.position;
    }

    #region Set Function
    public void SetVelocity(Vector3 normDir,float speed)
    {
        workspace = normDir * speed;
        SetLastVelocity();
    }

    public void SetVelocityX(Vector3 normDir,float speed)
    {
        workspace = new Vector3(normDir.x * speed, 0, 0);
        SetLastVelocity();
    }

    public void SetVelocityY(Vector3 normDir,float speed)
    {
        workspace = new Vector3(0, normDir.y * speed, 0);
        SetLastVelocity();
    }

    private void SetLastVelocity()
    {
        if (!canMove) return;
        _Tran.position += workspace;
    }
    #endregion
}
