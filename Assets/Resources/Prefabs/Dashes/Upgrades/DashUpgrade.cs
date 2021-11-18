using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashUpgrade : MonoBehaviour
{
    [System.NonSerialized]
    public Dash dash;
    public void Awake()
    {
        dash = transform.parent.GetComponent<Dash>();
    }
    public void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void AddPasive() 
    {

    }
}
