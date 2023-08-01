using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : CoreComponent
{
    private float maxHP;
    private float currentHP;

    public bool isDead { get; private set; }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    #region Set Function
    public void Initialize(float maxHP)
    {
        this.maxHP = maxHP;
        currentHP = maxHP;
        isDead = false;
    }

    public void addHealth(float add)
    {
        currentHP += Mathf.Abs(add);
    }

    public void subHealth(float sub)
    {
        currentHP -= Mathf.Abs(sub) * -1.0f;
        if (currentHP <= 0)
            isDead = true;
    }
    #endregion
}
