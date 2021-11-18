using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : State
{
    public float stunTime;
    void Start()
    {
        base.Start();
    }

    void Update()
    {
    }

    public void SetStunTime(float time)
    {
        stunTime = time;
    }
    public override void SetState()
    {
        base.SetState();
        character.DisableMovement(stunTime);
    }
}
