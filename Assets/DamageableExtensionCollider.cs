using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableExtensionCollider : Damageable
{
    public Damageable damageParent;
    void Start()
    {
        base.Start();
        damageParent = transform.parent.GetComponent<Damageable>();
        parent = damageParent.parent;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if(parent == null)
            parent = damageParent.parent;
    }
    public override void DisableInvencible()
    {
        damageParent.DisableInvencible();
    }
    public override void EnableInvencible()
    {
        damageParent.EnableInvencible();
    }
    public override void GetKnockBack(DamageDealer dealer)
    {
        damageParent.GetKnockBack(dealer);
    }
    public override void SetLayerToAlternative()
    {
        damageParent.SetLayerToAlternative();
    }
    public override void SetLayerToDefault()
    {
        damageParent.SetLayerToDefault();
    }
    public override void GetDamage(DamageDealer dealer)
    {
        damageParent.GetDamage(dealer);
    }
}
