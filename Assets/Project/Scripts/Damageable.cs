using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [System.NonSerialized]
    public CharacterController parent;
    [System.NonSerialized]
    public float hp;
    public CollisionType type;
    public Stat maxHp;
    public Stat invencibleDuration;
    public bool invencible;
    int defaultLayer;
    public GameObject onHitParticle;
    public List<Event> onDieEvents = new List<Event>();
    public List<Event> onGetHitEvents = new List<Event>();

    public void Start()
    {
        hp = maxHp.Value;
        parent = transform.parent.GetComponent<CharacterController>();
        defaultLayer = gameObject.layer;
    }

    public void Update()
    {
        
    }
    public virtual void GetDamage(DamageDealer dealer) 
    {
        if(invencible)
             return;
        EnableInvencible();
        OnGetHit(dealer);
        parent.anim.SetWhiteBlink(0.2f);
       // GetKnockBack(dealer);
        SpawnHeart((int)dealer.damage.Value);
        hp -= dealer.damage.Value;
        if (hp <= 0) 
        {
            Die(dealer);
        }
        Debug.Log(parent + " hp " + hp);
    }
    public virtual void GetKnockBack(DamageDealer dealer) 
    {
        //parent.movement.DisableMovement();
        //parent.movement.EnableMovement(dealer.knockbackDuration.Value);
        Vector2 dir = (transform.position - dealer.transform.position).normalized;
   

        parent.rb2d.AddForce(dir * dealer.knockback.Value,ForceMode2D.Impulse);
    }
    public virtual void EnableInvencible() 
    {
        invencible = true;
        Invoke("DisableInvencible", invencibleDuration.Value);
    }
    public virtual void EnableInvencible(float t)
    {
        invencible = true;
        Invoke("DisableInvencible", t);
    }
    public virtual void DisableInvencible()
    {
        invencible = false;
    }
    public virtual void SetLayerToAlternative() 
    {
        gameObject.layer = LayerMask.NameToLayer("GetAlternativeDamage");
    }
    public virtual void SetLayerToDefault()
    {
        gameObject.layer = defaultLayer; 
    }
    public void SpawnHeart(int cuantity) 
    {
        if (onHitParticle == null)
            return;
        for (int i = 0; i < cuantity; i++)
        {
            GameObject go = Instantiate(onHitParticle);
            go.transform.position = transform.position;
        }
    }
    public void Die(DamageDealer dealer) 
    {
        hp = 0;
        foreach (Event e in onDieEvents)
        {
            e(dealer);
        }
        Destroy(parent.gameObject);
    }
    public void OnGetHit(DamageDealer dealer)
    {
        foreach (Event e in onGetHitEvents)
        {
            e(dealer);
        }
    }

}
