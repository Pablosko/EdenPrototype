using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCollision : CharacterCollision
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float RecalculateDash(float distance)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, character.GetComponent<PlayerController>().charDash.dashDirection, distance, LayerMask.GetMask("BlockDash"));
        if (hit.collider != null)
        {
            float rayDistance = (hit.point - (Vector2)transform.position).magnitude;
            return distance - rayDistance;
        }
        return 0;
    }
}
