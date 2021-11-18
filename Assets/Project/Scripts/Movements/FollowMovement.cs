using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMovement : IAMovement
{
    [System.NonSerialized]
    public Transform target;
    bool following;
    public int stopRadius;
    public EnemyState stopMovementState;
    public EnemyState startMovementState;
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
        if (following)
            base.FixedUpdate();
    }
    public override void Movement()
    {
        SetFollowDirection();
        base.Movement();
        /*
        float distance = (target.position - transform.position).magnitude;
        following = (distance > stopRadius);
        */
    }
  
    public void StopFollowing() 
    {
        StopMovement();
        target = null;
        following = false;
        ia.state = stopMovementState;
    }
    public void StartMovement(Transform _target) 
    {
        target = _target;
        following = true;
        ia.state = startMovementState;

    }
    public void SetFollowDirection() 
    {
        if (target == null)
            return;
        SetDirection(target.position - transform.position);
    }
    public override void EnableMovement()
    {
        base.EnableMovement();
        SetFollowDirection();
    }
}
