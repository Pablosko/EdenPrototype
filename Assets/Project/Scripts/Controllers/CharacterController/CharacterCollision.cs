using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    [System.NonSerialized]
    public CharacterController character;
    [System.NonSerialized]
    public CapsuleCollider2D collider;
    public void Start()
    {
        character = transform.parent.GetComponent<CharacterController>();
        collider = GetComponent<CapsuleCollider2D>();
    }   

    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

    }
}
