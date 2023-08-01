using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreComponent : MonoBehaviour
{
    protected Core core;
    protected Vector3 workspace;

    protected virtual void Awake()
    {
        core = transform.parent.GetComponent<Core>();

        if (core == null) Debug.Log("Core��������܂���B");
        else core.AddCoreComponent(this);
    }

    protected virtual void Start() { }

    public virtual void LogicUpdate()
    {

    }
}
