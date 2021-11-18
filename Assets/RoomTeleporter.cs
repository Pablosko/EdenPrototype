using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTeleporter : MonoBehaviour
{
    [Header("If false go previous Room")]
    public bool nextRoom;
    MapGenerator map;
    public bool startActive;
    void Start()
    {
        map = FindObjectOfType<MapGenerator>();
        gameObject.SetActive(startActive);
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.transform.parent.GetComponent<PlayerController>();
        if (player != null) 
        {
            if(nextRoom)
            map.MoveRoom(1);
            else
            map.MoveRoom(-1);

        }
    }
}
