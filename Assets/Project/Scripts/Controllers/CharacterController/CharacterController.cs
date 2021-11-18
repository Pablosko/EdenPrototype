using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CharacterStats))]
[RequireComponent(typeof(CharacterMovement))]
public class CharacterController : MonoBehaviour
{
   // public List<Stat> stats = new List<Stat>();
    [System.NonSerialized]
    public Rigidbody2D rb2d;
    [System.NonSerialized]
    public CharacterMovement movement;
    [System.NonSerialized]
    public CharacterStats stats;
    [System.NonSerialized]
    public CharacterAnim anim;
    [System.NonSerialized]
    public CharacterCollision collision;
    [System.NonSerialized]
    public Damageable damageable;
    public List<EffectState> InmuneTypes = new List<EffectState>();
    public List<State> states = new List<State>();

    public void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        movement = GetComponent<CharacterMovement>();
        stats = GetComponent<CharacterStats>();
        anim = transform.Find("Animations").GetComponent<CharacterAnim>();
        collision = transform.Find("FloorCollisions").GetComponent<CharacterCollision>();
        damageable = transform.Find("DamageCollider").GetComponent<Damageable>();
        damageable.onDieEvents.Add(Die);
    }
    public void Start()
    {
    }

    public void Update()
    {
        if (Mathf.Abs(rb2d.velocity.magnitude) > 0.2)
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x) * Mathf.Sign(rb2d.velocity.x), transform.localScale.y);
    }
    public virtual void Die(DamageDealer dealer) 
    {
        print("Dead" + gameObject.name);
    }
    public void SetRigidBodyToZero() 
    {
        rb2d.velocity = Vector2.zero;
        rb2d.drag = 0;
    }
    public virtual void DisableMovement()
    {
        movement.DisableMovement();
    }
    public virtual void DisableMovement(float time)
    {
        movement.DisableMovement(time);
    }
    public virtual void EnableMovement()
    {
        movement.EnableMovement();
    }
    public bool IsInmune(EffectState type) 
    {
        foreach (EffectState e in InmuneTypes)
        {
            if (e == type)
                return true;
        }
        return false;
    }
    public void AddInmunization(EffectState type) 
    {
        InmuneTypes.Add(type);
    }
    public void AddInmunization(EffectState e,float time)
    {
        InmuneTypes.Add(e);
        Invoke("RemoveInmunization", time);
    }
    public void RemoveInmunization(EffectState type) 
    {
        InmuneTypes.Remove(type);
    }
    public void AddState(State state) 
    {
        states.Add(state);
    }
    public void RemoveState(State state)
    {
        state.RemoveState();
        states.Remove(state);
        Destroy(state);
    }
    public bool HasState(State state) 
    {
        return states.Contains(state);
    }
}
