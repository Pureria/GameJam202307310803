using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreComponent : MonoBehaviour
{
    private Core core;
    protected Vector3 workspace;

    protected virtual void Awake()
    {
        core = transform.parent.GetComponent<Core>();

        if (core == null) Debug.Log("CoreÇ™å©Ç¬Ç©ÇËÇ‹ÇπÇÒÅB");
        core.AddCoreComponent(this);
    }

    protected virtual void Start() { }

    public virtual void LogicUpdate()
    {

    }
}
