using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotMove : MonoBehaviour
{
    private Vector3 dir = Vector2.zero;
    private bool canMove;
    private void Start()
    {
        canMove = true;
    }

    private void FixedUpdate()
    {
        if(canMove)
            transform.position += dir;
    }

    public void SetDirection(Vector2 dir,float speed)
    {
        this.dir = new Vector3((dir.x * speed), (dir.y * speed), 0);
    }

    public void SetCanMove(bool canMove) => this.canMove = canMove;
}
