using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [System.NonSerialized]
    public List<GameObject> columnas = new List<GameObject>();
    [System.NonSerialized]
    public List<GameObject> pinchos = new List<GameObject>();
    [System.NonSerialized]
    public List<GameObject> lava = new List<GameObject>();
    [System.NonSerialized]
    public List<GameObject> hielo = new List<GameObject>();
    [System.NonSerialized]
    public List<GameObject> slime = new List<GameObject>();
    [System.NonSerialized]
    public List<GameObject> enemyPositions = new List<GameObject>();
    [System.NonSerialized]
    public Collider2D cameraLimits;
    [System.NonSerialized]
    public Vector2 playerSpawnPos;
    [System.NonSerialized]
    public Transform spawnedEnemys;
    [System.NonSerialized]
    public GameObject teleporter;
    [System.NonSerialized]
    public Transform enemys;
    [Header("Random Ranges")]
    public Vector2 colRange;
    public Vector2 enemyRange;
    public Vector2 slimeRange;
    public Vector2 lavaRange;
    public Vector2 iceRange;
    public Vector2 spikeRange;
    [Header("Rarity and repeticions")]
    public int maxTimesPerFloor;
    public int maxTimesInaRow;
    [Header("Debug")]
    public int cols;
    public int spikes;
    public int iceBlocks;
    public int lavaBlocks;
    public int slimeBlocks;
    public int totalMobs;
    
    public void Awake()
    {
        cameraLimits = transform.Find("CameraLimits").GetComponent<Collider2D>();
        playerSpawnPos = transform.Find("PlayerSpawnPos").position;
        spawnedEnemys = transform.Find("SpawnedEnemys");
        enemys = transform.Find("TilemapGrid").Find("Enemys");
        teleporter = FindObjectOfType<RoomTeleporter>().gameObject;
        GetAllChilds("Columnas", ref columnas);
        GetAllChilds("EnemyPositions", ref enemyPositions);
        GetAllChilds("Pinchos", ref pinchos);
        GetAllChilds("Lava", ref lava);
        GetAllChilds("Hielo", ref hielo);
        GetAllChilds("Slime", ref slime);

        GenObstacle(ref colRange,ref cols,ref columnas);
        GenObstacle(ref slimeRange, ref slimeBlocks, ref slime);
        GenObstacle(ref spikeRange, ref spikes, ref pinchos);
        GenObstacle(ref lavaRange, ref lavaBlocks, ref lava);
        GenObstacle(ref iceRange, ref iceBlocks, ref hielo);
        SpawnEnemys();

    }

    public void Update()
    {
        
    }
    public void GenObstacle(ref Vector2 range, ref int debugNum,ref List<GameObject> list) 
    {
        //por si alguien es subnormal y pone mas delas que hay o menos
        range.x = Mathf.Clamp(range.x, 0,list.Count);
        range.y = Mathf.Clamp(range.y, 0,list.Count);

        debugNum = (int)Random.Range(range.x, range.y);
        int objectstoDestroy = list.Count - debugNum;

        for (int i = 0; i < objectstoDestroy; i++) 
        {
            GameObject toDestroy = list[Random.Range(0, list.Count)];
            list.Remove(toDestroy);
            Destroy(toDestroy);

        }
    }
    public void GetAllChilds(string path, ref List<GameObject> list) 
    {
        Transform parent = transform.Find("TilemapGrid").Find("Obstacles").Find(path);
        foreach (Transform child in parent)
        {
            if(!child.GetComponent<DontDestroyOnGeneration>())
                list.Add(child.gameObject);
        }

    }
    public virtual void OpenTeleporter() 
    {
        teleporter.SetActive(true);
    }
    public void DieMobEvent() 
    {
        totalMobs--;
        if (totalMobs <= 0)
            OpenTeleporter();
    }
    public void SpawnEnemys() 
    {
        int num = 0;
        GenObstacle(ref enemyRange, ref num, ref enemyPositions);
        foreach (GameObject enemy in enemyPositions)
        {
            enemy.GetComponent<Instantible>().Spawn();
        }
    }
}
