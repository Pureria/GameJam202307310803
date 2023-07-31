using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : CoreComponent
{
    Vector3 currentPosition;

    public
        override void LogicUpdate()
    {
        base.LogicUpdate();

        currentPosition = transform.root.position;
    }

    #region Set Function
    //TODO::Movement::Movementコンポーネントの処理
    #endregion
}
