using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Lava : DamageDealer
{
    void Start()
    {
        base.Start();
        damageCollider = transform.GetComponent<DamageCollision>();
    }

    void Update()
    {
        
    }
    public override void DealDamage(Damageable target)
    {
        base.DealDamage(target);
    }
}
