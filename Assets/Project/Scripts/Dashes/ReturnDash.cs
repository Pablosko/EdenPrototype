using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnDash : ActivableDash
{
     [System.NonSerialized]
    SpriteRenderer copy;
    private void Awake()
    {
        base.Awake();
        copy = transform.Find("DashDamageCollider").Find("Copy").GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        base.Start();
        canUseActive = false;
    }

    void Update()
    {
        base.Update();
    }
    public override void StartDashing()
    {
        base.StartDashing();
        AudioController.InstanceAudio.PlayFx(Enums.Effects.returnDash);
        SetCopy(true);
        canUseActive = true;
        startPos = charDash.transform.position;
        charDash.character.rb2d.AddForce(charDash.dashDirection * impulse.Value);
        return;
    }
    public override void ResetDashTimer()
    {
        base.ResetDashTimer();
        SetCopy(false);
    }
    public override void Active()
    {
        base.Active();
        AudioController.InstanceAudio.PlayFx(Enums.Effects.returnDashBack);
        SetOwnerToStartingPos();
        SetCopy(false);
    }
    public override void SetOwner(CharacterController _character,int layer)
    {
        base.SetOwner(_character,layer);
        copy.sprite = _character.anim.gameObject.GetComponent<SpriteRenderer>().sprite;
        copy.enabled = false;
    }
    void SetCopy(bool state) 
    {
        Transform copyTransform = copy.gameObject.transform;
        copy.enabled = state;
        if (state) 
        {
            copyTransform.SetParent(null);
            return; 
        }
        copyTransform.SetParent(damageCollider.transform);
        copyTransform.localPosition = Vector2.zero;
    }
}
