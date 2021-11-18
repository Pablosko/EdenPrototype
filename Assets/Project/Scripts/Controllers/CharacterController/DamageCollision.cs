using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CollisionType 
{
    body,
    legs
}
[RequireComponent(typeof(BoxCollider2D))]
public class DamageCollision : MonoBehaviour
{
   [System.NonSerialized]
    public DamageDealer dealer;
    public CollisionType type;
    public void Start()
    {

    }

    void Update()
    {
        
    }
    //Daño de si 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable target = collision.GetComponent<Damageable>();
        if (target != null && target.type == type) 
        {
            dealer.DealDamage(target);
        }
    }
}
