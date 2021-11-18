using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDash : Dash
{
    void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        base.Start();
    }

    void Update()
    {
        base.Update();
    }
    public override void StartDashing()
    {
        base.StartDashing();
        AudioController.InstanceAudio.PlayFx(Enums.Effects.basicDash);
        charDash.character.rb2d.AddForce(charDash.dashDirection * impulse.Value);
    }
}
