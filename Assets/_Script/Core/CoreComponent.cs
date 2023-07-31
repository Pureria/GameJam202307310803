using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreComponent : MonoBehaviour
{
    Core core;
    Vector2 workspace;

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
