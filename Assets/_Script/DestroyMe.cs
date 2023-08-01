using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    [SerializeField]
    private float DestroyTime = 5.0f;
    private float startTime;

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        if (startTime + DestroyTime < Time.time)
            GameObject.Destroy(this.gameObject);
    }
}
