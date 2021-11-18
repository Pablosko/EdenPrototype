using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceUpgrade : DashUpgrade
{
    public float extraDistance;
    public float extraPercentageDistance;
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
        dash.impulse.extraflat -= extraDistance;
        dash.cooldown.extraPercentage -= extraPercentageDistance;
    }
}
