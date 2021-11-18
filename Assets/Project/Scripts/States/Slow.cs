using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : State
{
    public Stat slow;
    void Start()
    {
        base.Start();
        SetState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void SetState()
    {
        base.SetState();
        if(!character.IsInmune(EffectState.Slow))
            character.stats.aceleration.Add(slow);
    }
    public override void RemoveState()
    {
        base.RemoveState();
        character.stats.aceleration.Reduce(slow);
    }
}
