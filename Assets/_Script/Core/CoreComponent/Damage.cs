using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : CoreComponent
{
    private Status Status { get => status ?? core.GetCoreComponent(ref status); }
    private Status status;

    private float currentDamage;
    private bool canDamage;
    protected override void Awake()
    {
        base.Awake();
        canDamage = true;
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
    public void AddDamage(float amount)
    {
        currentDamage = amount;
        Debug.Log(transform.root.transform.name + " is " + currentDamage + " Damage");
        SetFinalDamage();
    }

    private void SetFinalDamage()
    {
        if(canDamage)
            Status?.subHealth(currentDamage);
    }

    public void SetCanDamage(bool canDamage) => this.canDamage = canDamage;
    #endregion
}
