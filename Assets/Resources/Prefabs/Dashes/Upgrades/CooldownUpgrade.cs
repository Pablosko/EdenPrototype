using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownUpgrade : DashUpgrade
{
    public float timeInSeconds;
    public float percentageReduced;
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
        dash.cooldown.extraflat -= timeInSeconds;
        dash.cooldown.extraPercentage -=  percentageReduced;
    }
}
