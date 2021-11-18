using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickySlimeFloor : MonoBehaviour
{
    public Stat slowEffect;
    List<Slow> addedStates = new List<Slow>();
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable coll = collision.GetComponent<Damageable>();
        if (coll == null)
            return;
        if (coll.type == CollisionType.legs) 
        {
            CharacterController target = coll.parent;
            print("applySlow");
            if (!target.IsInmune(EffectState.Slow))
            {
               
                Slow slow = target.gameObject.AddComponent<Slow>();
                slow.slow = slowEffect;
                addedStates.Add(slow);
                target.AddState(slow);
                CharacterDash dashscript = target.GetComponent<CharacterDash>();
                if (dashscript) 
                {
                    dashscript.CutDash();
                    dashscript.isDashBloqued = true;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Damageable coll = collision.GetComponent<Damageable>();
        if (coll == null)
            return;
        if (coll.type != CollisionType.legs)
            return;
        CharacterController target = coll.parent;
        State state = HasOneOfMyStates(target);
        if (state != null)
        {
            print("removeSlow");
            target.RemoveState(state);
        }
        CharacterDash dashscript = target.GetComponent<CharacterDash>();
        if (dashscript)
        {
            dashscript.isDashBloqued = false;
        }
    }
    public State HasOneOfMyStates(CharacterController character) 
    {
        foreach (State state in addedStates)
        {
            if (character.HasState(state))
                return state;
        }
        return null;
    }
}
