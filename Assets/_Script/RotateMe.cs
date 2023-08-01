using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMe : MonoBehaviour
{
    [SerializeField]
    private float _rotateSpeed = 100f;
    private float angle;

    private void Update()
    {
        angle += _rotateSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
