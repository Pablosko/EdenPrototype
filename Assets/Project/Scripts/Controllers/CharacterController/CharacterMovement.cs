using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [System.NonSerialized]
    public CharacterController character;
    public Vector2 direction;
    public bool canMove;
    public bool canSetDirection;

    public void Awake()
    {
        character = GetComponent<CharacterController>();
    }
    public void Start()
    {
        EnableMovement();
        SetDynamicDirection();
    }

    public void Update()
    {
    
    }

    public virtual void Movement()
    {

    } 
    public virtual void StopMovement() 
    {
        direction = Vector2.zero;
        character.rb2d.velocity = Vector2.zero;
    }
    public virtual void DisableMovement() 
    {
        canMove = false;
        StopMovement();
    }
    public virtual void DisableMovement(float time)
    {
        canMove = false;
        StopMovement();
        Invoke("EnableMovement", time);
    }
    public virtual void EnableMovement() 
    {
        canMove = true;
    }
    public virtual void SetDirection(Vector2 newDirection) 
    {
        if (!canSetDirection)
            return;
        direction = newDirection.normalized;
    }
    public virtual void SetDirectionAndNotNormalize(Vector2 newDirection) 
    {

        if (!canSetDirection)
            return;
        direction = newDirection;
    }
    public void SetStaticDirection() 
    {
        canSetDirection = false;
    }
    public void SetDynamicDirection()
    {
        canSetDirection = true;
    }
    public void EnableMovement(float t) 
    {
        Invoke("EnableMovement", t);
    }
}
