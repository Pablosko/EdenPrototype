using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : Instantible
{
    public bool destroyOnEnd;
    public Vector2 mobsRange;
    public Vector2 randomTimeRange;
    public GameObject mob;
    float currentTime;
    float randomTime;
    int mobs;
    int spawnedMobs;
    bool start;
    void Awake()
    {
        base.Awake();
    }

    void Update()
    {
        if (!start)
            return;

        currentTime += Time.deltaTime;
        if (currentTime >= randomTime) 
        {
            SpawnMob();
        }

    }
    public void Die() 
    {
        Destroy(gameObject);
    }
    void SpawnMob() 
    {
        GameObject go = Instantiate(mob,room.spawnedEnemys);
        go.transform.position = transform.position;
        spawnedMobs++;
        SetRandomTime();
        if (spawnedMobs >= mobs)
            Die();
    }
    void SetRandomTime() 
    {
        currentTime = 0;
        randomTime = Random.Range(randomTimeRange.x, randomTimeRange.y);
    }
    public override void Spawn()
    {
        base.Spawn();
        SetRandomTime();
        mobs = (int)Random.Range(mobsRange.x, mobsRange.y);
        start = true;
    }
}
