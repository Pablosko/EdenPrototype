using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FollowMovement))]
[RequireComponent(typeof(PatrolMovement))]

public class Slime : EnemyController
{
    [System.NonSerialized]
    public FollowMovement follow;
    [System.NonSerialized]
    public PatrolMovement patrol;
    private void Awake()
    {
        base.Awake();
        follow = GetComponent<FollowMovement>();
        patrol = GetComponent<PatrolMovement>();

    }

    void Start()
    {
        base.Start();
        follow.enabled = false;
        patrol.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
    public override void Wandering()
    {
        base.Wandering();
        patrol.enabled = true;
        follow.enabled = false;
    }
    public override void Chasing()
    {
        base.Chasing();
        patrol.enabled = false;
        follow.enabled = true;
    }


}
