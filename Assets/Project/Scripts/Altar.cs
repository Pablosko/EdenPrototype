using UnityEngine;

public class Altar : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject spawnedObject;
    public LootRoom room;
    ObjectsManager objectsManager;
    bool picked;
    private void Awake()
    {
        objectsManager = GameController.Instance.objectsManager;
        //GetSpawnObject();
        SpawnObject();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
    }
    void SpawnObject() 
    {
        spawnedObject = Instantiate(objectToSpawn, transform.GetChild(0));
        spawnedObject.transform.localPosition = new Vector2(-21.5f, 10.1f);
    }
    void GetSpawnObject() 
    {
        if (!GameController.Instance.player.charDash.HasMaxDashes())
        {
            objectToSpawn = objectsManager.GetRandomDash();
            return;
        }
            objectToSpawn = objectsManager.GetRandomUpgrade();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (picked)
            return;
        if (spawnedObject == null)
            return;
        PlayerCollect collider = collision.GetComponent<PlayerCollect>();
        if (collider == null)
            return;
        PlayerController player = collider.player;
        if (player== null)
            return;
        Dash dash = spawnedObject.GetComponent<Dash>();
        if(dash != null) 
        {
            CollectDash(player, dash);
            return;
        }
        DashUpgrade upgrade = spawnedObject.GetComponent<DashUpgrade>();

        if (upgrade != null)
        {
            return;
        }

    }
    public void CollectDash(PlayerController player,Dash dash) 
    {
        dash.transform.SetParent(player.container.transform);
        player.charDash.AddDash(dash, LayerMask.NameToLayer("PlayerDealDamage"));
        dash.GetComponent<SpriteRenderer>().enabled = false;
        dash.transform.localPosition = Vector2.zero;
        GameObject trail = Instantiate(dash.trail, player.charDash.trailsTransform);
        trail.SetActive(false);
        player.charDash.trails.Add(trail);
        player.charDash.UpdateTrail();
        DestroyChildAndCollider();
        room.ItemPicked();
        picked = true;
    }
    public void CollectUpgrade(PlayerController player, Dash upgrade) 
    {
        DestroyChildAndCollider();
        room.ItemPicked();
    }
    public void ReturnItemToPool() 
    {
        if (objectToSpawn != null) 
        {
            Dash dash = objectToSpawn.GetComponent<Dash>();
            if (dash != null)
            {
                objectsManager.AddDashToPool(objectToSpawn);
            }
            DashUpgrade upgrade = objectToSpawn.GetComponent<DashUpgrade>();

            if (upgrade != null)
            {
                objectsManager.AddUpgradeToPool(objectToSpawn);
            }
            DestroyChildAndCollider();
        }

    }
    public void DestroyChildAndCollider() 
    {
        if (transform.childCount > 0)
            Destroy(transform.GetChild(0).gameObject);
        Destroy(GetComponent<CircleCollider2D>());
    }
}
