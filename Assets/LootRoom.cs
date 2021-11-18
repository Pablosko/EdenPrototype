using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootRoom : Room
{
    [System.NonSerialized]
    public List<Altar> altars = new List<Altar>();
    [Header("LOOT")]
    public int pickeableItems;
    int pickedItems;
    private void Awake()
    {
        base.Awake();
        GetAltars();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ItemPicked() 
    {
        pickedItems++;
        if (pickedItems >= pickeableItems) 
        {
            foreach (Altar altar in altars)
            {
                altar.ReturnItemToPool();
            }
            OpenTeleporter();
        }
    }
    public void GetAltars() 
    {
        Transform parent = transform.Find("TilemapGrid").Find("Decoration");
        foreach (Transform child in parent)
        {
            Altar altar = child.gameObject.GetComponent<Altar>();
            altars.Add(altar);
            altar.room = this;
        }
    }
}
