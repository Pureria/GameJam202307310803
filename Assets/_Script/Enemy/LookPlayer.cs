using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPlayer : MonoBehaviour
{
    private void Update()
    {
        Vector3 pTran = GameManager.Instance.Player.transform.position;
        if(pTran != null)
        {
            Vector3 diff = (pTran - this.transform.position).normalized;
            this.transform.rotation = Quaternion.FromToRotation(Vector3.down, diff);
        }
    }
}
