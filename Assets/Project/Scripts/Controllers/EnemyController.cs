using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public enum EnemyState 
    {
        Attacking,
        Wandering,
        Chasing
    }
public class EnemyController : CharacterController
{
    [SerializeField]
    Transform target;
    public EnemyState state;
    public List<CharacterMovement> movements;
    public Room room;
    private void Awake()
    {
        base.Awake();
    }
    public void Start()
    {
        base.Start();
        state = EnemyState.Wandering;
        target = GameController.Instance.player.transform;
        movements.AddRange(GetComponents<CharacterMovement>());
        room = transform.parent.parent.GetComponent<Room>();
        room.totalMobs++;
    }

    public void Update()
    {
        base.Update();
        switch (state)
        {
            case EnemyState.Wandering:
                Wandering();
                break;
            case EnemyState.Chasing:
                Chasing();
                break;
            case EnemyState.Attacking:
                Attacking();
                break;
            default:
                break;
        }
    }
    public virtual void Wandering() 
    {

    }
    public virtual void Attacking()
    {

    }
    public virtual void Chasing()
    {

    }
    public override void DisableMovement()
    {
        foreach (CharacterMovement movement in movements)
        {
            movement.DisableMovement();
        }
    }
    public override void DisableMovement(float  time)
    {
        foreach (CharacterMovement movement in movements)
        {
            movement.DisableMovement(time);
        }
    }
    public override void EnableMovement()
    {
        foreach (CharacterMovement movement in movements)
        {
            movement.EnableMovement();
        }
    }
    public override void Die(DamageDealer dealer)
    {
        room.DieMobEvent();
        base.Die(dealer);
    }
}
