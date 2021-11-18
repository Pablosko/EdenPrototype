using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Spike : DamageDealer
{

    void Start()
    {
        damageCollider = transform.GetComponent<DamageCollision>();
        Activate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Activate() 
    {
        damageCollider.enabled = true;
    }
}
