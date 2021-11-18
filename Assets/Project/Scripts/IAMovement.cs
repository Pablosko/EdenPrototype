using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAMovement : CharacterMovement
{
    [System.NonSerialized]
    public EnemyController ia;
    public void Awake()
    {
        base.Awake();
        ia = GetComponent<EnemyController>();
    }
    public void Start()
    {
        base.Start();
    }

    public void FixedUpdate()
    {
        if (canMove)
            Movement();
    }
    public override void Movement()
    {
        base.Movement();
        character.rb2d.AddForce(direction * character.stats.aceleration.Value * Time.fixedDeltaTime,ForceMode2D.Impulse);
        character.rb2d.velocity = Vector2.ClampMagnitude(character.rb2d.velocity, character.stats.maxSpeed.Value);
    }
}
