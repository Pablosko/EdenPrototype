using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [Header("Damage dealer")]
    public Stat damage;
    public Stat knockback;
    public Stat knockbackDuration;
    public DamageCollision damageCollider;
    public void Awake()
    {
        damageCollider.dealer = this;
    }
    public void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void DealDamage(Damageable target) 
    {
        target.GetDamage(this);
    }
    public virtual void ActivateDamageCollider() 
    {
        damageCollider.gameObject.SetActive(true);
    }
    public virtual void UnActivateDamageCollider()
    {
        damageCollider.gameObject.SetActive(false);
    }
}
