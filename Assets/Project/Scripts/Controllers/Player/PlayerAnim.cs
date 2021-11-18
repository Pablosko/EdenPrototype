using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : CharacterAnim
{
    [System.NonSerialized]
    public PlayerController player;


    void Awake()
    {
        base.Awake();
        player = transform.parent.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        anim.SetBool("IsDashing", player.charDash.isDashing);
    }
}
