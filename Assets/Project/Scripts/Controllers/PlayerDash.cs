using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : CharacterDash
{
    private void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        base.Start();
        
    }

    void Update()
    {
    }
    public override Vector2 GetDashDir()
    {
        /*Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        Vector2 position = (mouse - (Vector2)transform.position);*/
        Vector2 dir;
        dir = character.GetComponent<PlayerMovement>().lastFacingDir;

        return dir.normalized;
    }
    public override void ChangeDash(int index)
    {
        base.ChangeDash(index);
        UpdateTrail();
        GameController.Instance.hud.UpdateDashPositions();
    }
    public override void AddDash(Dash dash, int layer)
    {
        GameController.Instance.hud.AddDash(dash);
        base.AddDash(dash,layer);
    }
}
