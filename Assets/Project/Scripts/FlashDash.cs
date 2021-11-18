using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashDash : Dash
{
    float useCounter;
    public float maxUseTime;
    public Stat preDashSpeed;
    float slowTime = 4;
    List<Vector2> positions = new List<Vector2>();
    bool fakeDashing;
    bool storingPositions;
    float fakedistance;
    float duration = 0;
    float durationCounter;
    SpriteRenderer copy;
    public GameObject particle;
    bool countFake;
    bool reducedToNormal;
    private void Awake()
    {
        base.Awake();
        copy = transform.Find("DashDamageCollider").Find("Copy").GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        base.Start();
        fakeDashing = true;
        duration = maxDistance.Value / impulse.Value;
    }

    void Update()
    {
        base.Update();
        if (charDash) 
        {
            if (storingPositions) 
            {
                safePosition();
                if (FakeDistanceMax()) 
                {
                    StopFakeDashing();
                    StartDashing();
                }

            }
        }
    }
    public override void StartDashing()
    {
        charDash.isDashBloqued = true;
        if (!fakeDashing)
        {
            base.StartDashing();
            AudioController.InstanceAudio.PlayFx(Enums.Effects.flashDash);
            ResetFakeStats();
        }
        else
        {
            AudioController.InstanceAudio.PlayFx(Enums.Effects.flashDashSlowMotion);
            dashui.SetHudOfActivation(true);
            DisableCharacterCollisionDamage(true);
            copy.enabled = true;
            startPos = character.transform.position;
            damageCollider.transform.SetParent(null);
            storingPositions = true;    
            character.stats.aceleration.extraTotalPercentage += preDashSpeed.Value * 100f;
            Time.timeScale = 1f / slowTime;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
    }
    public override void StopDashing()
    {
        base.StopDashing();
        positions = new List<Vector2>();
        fakeDashing = true;
        copy.enabled = false;
        charDash.isDashBloqued = false;
        durationCounter = 0;
        damageCollider.transform.SetParent(transform);
        damageCollider.transform.localPosition = Vector2.zero;
    }
    bool FakeDistanceMax() 
    {
        useCounter += Time.unscaledDeltaTime;
        if (positions.Count > 1 && countFake) 
        {
            fakedistance += Mathf.Abs((positions[positions.Count - 2] - positions[positions.Count - 1]).magnitude);
        }
        dashui.SetActivefillImage(useCounter, maxUseTime);
        return ((fakedistance >= maxDistance.Value) || ( useCounter >= maxUseTime));
    }
    public override void CalcDistance() 
    {
        if (durationCounter >= duration) 
        {
            StopDashing();
            return;
        }
        durationCounter += Time.deltaTime;
        int index = (int)((currentTime / duration) * positions.Count);
        putParticle(positions[index], damageCollider.gameObject.transform.position, particle);
        damageCollider.gameObject.transform.position = positions[index];
    }
    void ResetFakeStats() 
    {
        fakedistance = 0;
        Time.timeScale = 1;
        reducedDistance = 0;
        Time.fixedDeltaTime = Time.fixedUnscaledDeltaTime;
        character.stats.aceleration.extraTotalPercentage -= preDashSpeed.Value * 100f;
        dashui.SetHudOfActivation(false);
    }
    void safePosition() 
    {
        countFake = !positions.Contains(character.transform.position);
        if (countFake)
         positions.Add(character.transform.position);
    }
    public override void SetOwner(CharacterController _character, int layer)
    {
        base.SetOwner(_character,layer);
        copy.sprite = _character.anim.gameObject.GetComponent<SpriteRenderer>().sprite;
        copy.enabled = false;
    }
    void putParticle(Vector2 a,Vector2 b,GameObject part) 
    {
        Transform particle = Instantiate(part).transform;
        //primer rayo
        Vector2 dir = (b - a);
        particle.position = a;
        particle.localScale = new Vector2(1, dir.magnitude / 2);
        float angle = Vector2.SignedAngle(Vector2.down, dir);
        particle.rotation = Quaternion.Euler(0f, 0f,angle);
        Destroy(particle.gameObject, 1f);
        //segundo inclinado
    }
    public void StopFakeDashing() 
    {
        fakeDashing = false;
        useCounter = 0;
        storingPositions = false;
    }
    public override void InterruptDash()
    {
        base.InterruptDash();
        StopFakeDashing();
        ResetFakeStats();
        fakeDashing = true;
        character.stats.aceleration.extraTotalPercentage = 0;
    }

}
