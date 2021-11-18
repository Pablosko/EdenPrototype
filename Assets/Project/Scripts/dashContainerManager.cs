using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashContainerManager : MonoBehaviour
{
    public List<Transform> transforms ;
    public List<DashUI> dashes;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void setDashPosition(Transform transform,int index) 
    {
        if (index >= GameController.Instance.player.charDash.dashes.Count)
            index = 0;
        if (index < 0)
            index = GameController.Instance.player.charDash.dashes.Count - 1;

        dashes[index].transform.position = transform.position;
        dashes[index].transform.localScale = transform.localScale;
    }
    public void PutAllDashesPositions() 
    {
        int current = GameController.Instance.player.charDash.currentDash;
        setDashPosition(transforms[0],current);
        if(dashes.Count > 1)
            setDashPosition(transforms[1], current + 1);
        if (dashes.Count > 2)
            setDashPosition(transforms[2], current - 1);
    }
}
