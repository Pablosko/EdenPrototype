using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsManager : MonoBehaviour
{
    public List<GameObject> dashes;
    public List<GameObject> upgrades;
    // Start is called before the first frame update
    void Awake()
    {
        LoadAllDashes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LoadAllDashes() 
    {
        dashes.AddRange(Resources.LoadAll<GameObject>("Prefabs/Dashes/Objects"));
    }
    public GameObject GetRandomDash() 
    {
        if (dashes.Count <= 0)
            return null;
        GameObject dash = dashes[Random.Range(0, dashes.Count)];
        dashes.Remove(dash);
        return dash;
    }
    public void AddDashToPool(GameObject dash) 
    {
        dashes.Add(dash);
    }
    public void AddUpgradeToPool(GameObject dash)
    {
        dashes.Add(dash);
    }
    public GameObject GetRandomUpgrade()
    {
        if (upgrades.Count <= 0)
            return null;
        GameObject upgrade = upgrades[Random.Range(0, upgrades.Count)];
        dashes.Remove(upgrade);
        return upgrade;
    }

}
