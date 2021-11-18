using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterAnim))]
public class MoveLikeSlime : MonoBehaviour
{
    CharacterController character;
    CharacterAnim anim;
    public Vector2 jumpDuration;
    public Vector2 channelingDuration;
    public List<CharacterMovement> movements = new List<CharacterMovement>();
    public bool jumping;

    void Start()
    {
        character = transform.parent.GetComponent<CharacterController>();
        movements.AddRange(transform.parent.GetComponents<CharacterMovement>());
        anim = character.anim;
    }
    void Update()
    {
        if (!jumping )
        {
            if(character.rb2d.velocity.magnitude != 0)
                Channel();
             else
             jumping = false;
        }
       
    }
    public void Jump() 
    {
        foreach (CharacterMovement movement in movements)
        {
            movement.EnableMovement();
            movement.SetStaticDirection();
        }
        float rand = Random.Range(jumpDuration.x, jumpDuration.y);
        anim.anim.speed = 1 / rand;
    }
    public void Channel() 
    {
        jumping = true;
        foreach (CharacterMovement movement in movements)
        {
            movement.DisableMovement();
            movement.SetDynamicDirection();
        }
        float rand = Random.Range(channelingDuration.x, channelingDuration.y);
        anim.anim.speed = 1 / rand;
        anim.anim.SetTrigger("Channel");
    }
    
}
