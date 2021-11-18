using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EffectState 
{
    Slow,
    Stund,
}
public class State : MonoBehaviour
{
    public CharacterController character;
    public void Start()
    {
        character = GetComponent<CharacterController>();
    }

    void Update()
    {
        
    }
    public virtual void SetState() 
    {

    }
    public virtual void RemoveState() 
    {
        
    }
}
