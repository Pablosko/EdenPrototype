using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivableDash : Dash
{
    public float activeTime;
    [System.NonSerialized]
    public float currentActiveTime;
    [System.NonSerialized]
    public bool canUseActive;
    public void Awake()
    {
        base.Awake();
    }
    public void Start()
    {
        base.Start();
    }
    public void Update()
    {
        base.Update();
        if (canUseActive)
        {
            ReloadActiveTime();
        }
    }
    public override void Use()
    {
        if (canUseActive)
        {
            Active();
            return;
        }
        base.Use();
    }
    public virtual void Active()
    {
        ResetDashTimer();
    }
    public virtual void ReloadActiveTime()
    {
        currentActiveTime += Time.deltaTime;
        dashui.SetActivefillImage(currentActiveTime, activeTime);
        if (currentActiveTime >= activeTime)
            ResetDashTimer();
    }
    public virtual void ResetDashTimer()
    {
        currentActiveTime = 0;
        canUseActive = false;
        dashui.SetHudOfActivation(canUseActive);
    }
    public override void StartDashing()
    {
        base.StartDashing();
        dashui.SetHudOfActivation(true);
    }
    public override void InterruptDash()
    {
        base.InterruptDash();
        ResetDashTimer();
    }
}
