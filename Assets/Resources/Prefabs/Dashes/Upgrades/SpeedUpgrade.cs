using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgrade : DashUpgrade
{
    public float extraSpeed;
    public float extraPercentageSpeed;
    private void Awake()
    {
        base.Awake();
    }
    void Start()
    {
    }

    void Update()
    {

    }
    public override void AddPasive()
    {
        base.AddPasive();
        dash.impulse.extraflat -= extraSpeed;
        dash.cooldown.extraPercentage -= extraPercentageSpeed;
    }
}

