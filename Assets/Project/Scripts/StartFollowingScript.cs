using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]
public class StartFollowingScript : MonoBehaviour
{
    FollowMovement FollowMovement;
    public LayerMask layerType;
    int layer;
    void Start()
    {
        FollowMovement = transform.parent.GetComponent<FollowMovement>();
        layer = (int)Mathf.Log(layerType.value, 2);
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == layer)
            FollowMovement.StartMovement(collision.transform);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == layer)
            FollowMovement.StopFollowing();
    }
}
