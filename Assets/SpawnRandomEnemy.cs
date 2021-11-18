using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomEnemy : Instantible
{
    public List<GameObject> enemys = new List<GameObject>();
    void Awake()
    {
        base.Awake();
    }

    void Update()
    {
        
    }
    public override void Spawn()
    {
        if (enemys.Count <= 0)
            return;

        int index = Random.Range(0, enemys.Count);
        GameObject go = Instantiate(enemys[index], transform.parent.parent.parent.GetComponent<Room>().enemys);
        go.transform.position = transform.position;

        room.totalMobs++;
    }
  
}
