using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class NonDamageCollision : DamageCollision
{
    StunDash stunDash;
    // Start is called before the first frame update
    void Start()
    {
        stunDash = GetComponent<StunDash>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable target = collision.GetComponent<Damageable>();
        if (target != null && target.type == type)
        {
            target.parent.DisableMovement();
            
        }
    }
}
