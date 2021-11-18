using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Dash : DamageDealer
{
    [System.NonSerialized]
    public Vector2 startPos;
    [System.NonSerialized]
    public CharacterDash charDash;
    [System.NonSerialized]
    public CharacterController character;
    public GameObject trail;
    public List<DashUpgrade> upgrades = new List<DashUpgrade>();
    [System.NonSerialized]
    public float dashedDistance;
    [System.NonSerialized]
    public float reducedDistance;
    [System.NonSerialized]

    public float currentTime;
    public Stat maxDistance;
    public Stat impulse;
    public Stat cooldown;
    public bool disableCharacterCollisionDamage;
    public float invencibleAfterFlash;

    //esto no deberia ser asi pero lo es
    [System.NonSerialized]
    public DashUI dashui;

    public void Awake()
    {
        base.Awake();
        if (upgrades.Count <= 0)
            upgrades.AddRange(transform.Find("Upgrades").GetComponentsInChildren<DashUpgrade>());
        UnActivateDamageCollider();
    }
    public void Start()
    {
        base.Start();
        currentTime = cooldown.Value;
        disableCharacterCollisionDamage = true;
    }

    public void Update()
    {
        if (charDash)
        {
            if (charDash.isDashing && charDash.dashingDash == this)
                CalcDistance();

            if (currentTime <= cooldown.Value)
                ReloadCd();
        }
    }
    public virtual void Use()
    {

        if (charDash.dashingDash == this || isInCd())
        {
            return;
        }
        if (isInCd())
        {
            AudioController.InstanceAudio.PlayFx(Enums.Effects.dashNoCd);
        }
        StartDashing();
    }
    public virtual void ReloadCd()
    {
        currentTime += Time.deltaTime;

        dashui.SetCDFillAmount(currentTime, cooldown.Value);
        if (currentTime >= cooldown.Value)
        {
            currentTime = cooldown.Value;
            dashui.SetCooldownState(false);
        }
    }
    public void RecalculateDashDistance()
    {
        reducedDistance = 0;
        RaycastHit2D hit = Physics2D.CapsuleCast(character.collision.transform.position, character.collision.collider.size, character.collision.collider.direction, 0, charDash.dashDirection, maxDistance.Value, LayerMask.GetMask("BlockDash"));
        if (hit.collider != null)
        {
            float rayDistance = Vector2.Distance(hit.point, character.collision.transform.position);
            reducedDistance = maxDistance.Value - rayDistance + character.collision.collider.size.x * 1.1f;
        }
    }
    public virtual void CalcDistance()
    {
        dashedDistance = Mathf.Abs(((Vector2)character.transform.position - startPos).magnitude) + reducedDistance;
        if (dashedDistance >= maxDistance.Value)
        {
            StopDashing();
            dashedDistance = 0;
        }
    }

    public virtual void StartDashing()
    {
        charDash.isDashing = true;
        startPos = charDash.transform.position;
        charDash.dashingDash = this;
        charDash.character.SetRigidBodyToZero();
        DisableCharacterCollisionDamage(true);
        ActivateDamageCollider();
        RecalculateDashDistance();
        StartDashCD();
    }
    public virtual void StopDashing()
    {
        UnActivateDamageCollider();
        character.damageable.EnableInvencible(invencibleAfterFlash);
        DisableCharacterCollisionDamage(false);
        character.GetComponent<CharacterDash>().StopDashing();
    }
    public virtual void InterruptDash()
    {
        StopDashing();
        FillCD();
    }
    public void StartDashCD()
    {
        dashui.SetCooldownState(true);
        currentTime = 0;
    }
    public void FillCD() 
    {
        currentTime = cooldown.Value;
    }
    public void FillCD(float percentage)
    {
        currentTime += cooldown.Value * percentage /100;
        if (currentTime >= cooldown.Value)
            currentTime = cooldown.Value;
    }
    public bool isInCd()
    {
        return (currentTime < cooldown.Value);
    }
    public void SetOwnerToStartingPos()
    {
        charDash.transform.position = startPos;
    }
    public virtual void SetOwner(CharacterController _character,int layer) 
    {
        character = _character;
        charDash = _character.GetComponent<CharacterDash>();
        damageCollider.gameObject.layer = layer;

        int index = GameController.Instance.player.charDash.dashes.IndexOf(this);
        dashui = GameController.Instance.hud.dashes[index];
        dashui.iconSprite = GetComponent<SpriteRenderer>().sprite;
    }
    public virtual void DisableCharacterCollisionDamage(bool state) 
    {
        if (state) 
        {
            if (disableCharacterCollisionDamage)
                character.damageable.SetLayerToAlternative();
            return;
        }
        character.damageable.SetLayerToDefault();
    }
}
