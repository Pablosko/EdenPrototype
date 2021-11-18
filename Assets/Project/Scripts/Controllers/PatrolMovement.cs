using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMovement : IAMovement
{
    public float idleTime;
    public float walkTime;
    public float counterTime;
    public bool idling;
    public Vector2 randomWalkTime;
    public Vector2 randomIdleTime;
    private void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        base.FixedUpdate();
    }
    void SetNewDirecction() 
    {
        SetDirection(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)));
    }
    void SetWait() 
    {
        idleTime = Random.Range(randomIdleTime.x, randomIdleTime.y);
        counterTime = 0;
        idling = true;
        StopMovement();
        character.rb2d.velocity = Vector2.zero;
    }
    void SetWalk() 
    {
        idling = false;
        counterTime = 0;
        walkTime = Random.Range(randomWalkTime.x, randomWalkTime.y);
        SetNewDirecction();
    }
    public override void Movement()
    {
        base.Movement();
        counterTime += Time.deltaTime;
        if (idling) 
        {
            if (counterTime >= idleTime)
                SetWalk();
        }
        else if (counterTime >= walkTime)
            SetWait();

        base.Movement();
    }
    public override void EnableMovement()
    {
        base.EnableMovement();
        SetNewDirecction();
    }

}
