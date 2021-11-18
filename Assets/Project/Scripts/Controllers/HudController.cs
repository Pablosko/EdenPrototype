using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    PlayerController player;
    public List<DashUI> dashes = new List<DashUI>();
    public List<Transform> dashesTransforms = new List<Transform>();
    public Transform dashContainer;
    public GameObject dashUiGameObject;
    public GameObject hpGameObject;
    public Transform hpContainer;
    public dashContainerManager dashContainerManager;
    public Animator animator;
    void Start()
    {
        player = GameController.Instance.player;
        player.damageable.onGetHitEvents.Add(RemoveHeart);
        animator = GetComponent<Animator>();
        InstantiateVidas();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateDashPositions() 
    {
        dashContainerManager.PutAllDashesPositions();
    }
    
    public void AddDash(Dash dash) 
    {
        if (GameController.Instance.player.charDash.HasMaxDashes())
            return;
        DashUI ui = Instantiate(dashUiGameObject,dashContainerManager.transform).GetComponent<DashUI>(); 
        dashes.Add(ui);
        dashContainerManager.dashes.Add(ui);
        ui.index = dashes.Count - 1;
        ui.gameObject.name = "" + (dashes.Count - 1);
    }
    public void InstantiateVidas() 
    {
        for (int i = 0; i < player.damageable.maxHp.Value; i++) 
        {
            Instantiate(hpGameObject, hpContainer);
        }
    }
    public void RemoveHeart(DamageDealer dealer) 
    {
        Destroy(hpContainer.GetChild(0).gameObject);
    }
    public void PlayFadeOff(float time) 
    {
        animator.speed = 1 / time;
        animator.SetTrigger("FadeOff");
        Invoke("resetAnimSpeed", time);
    }
    public void PlayFadeOffStartingBack(float time)
    {
        animator.speed = 1 / time;
        animator.SetTrigger("ReverseFade");
        Invoke("resetAnimSpeed", time);
    }
    public void resetAnimSpeed() 
    {
        animator.speed = 1;
    }

}
