using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DashUI : MonoBehaviour
{
    public Image backgroundImage;
    public Image fillActiveImage;
    public Image icon;
    public Sprite iconSprite;
    public Image cdFillImage;
    public TextMeshProUGUI cdText;
    public GameObject activeGameObject;
    public dashContainerManager dashContainerManager;
    public int index;
    void Start()
    {
        backgroundImage = transform.Find("Background").GetComponent<Image>();
        icon = transform.Find("Icon").GetComponent<Image>();
        cdFillImage = transform.Find("CdObject").GetComponent<Image>();
        cdText = cdFillImage.transform.Find("CdText").GetComponent<TextMeshProUGUI>();
        activeGameObject = transform.Find("ActiveCd").gameObject;
        fillActiveImage = activeGameObject.transform.Find("Fill").GetComponent<Image>();
        icon.sprite = iconSprite;
        dashContainerManager = GameController.Instance.hud.dashContainerManager;
        dashContainerManager.PutAllDashesPositions();
    }

    void Update()
    {
        
    }
    public void SetHudOfActivation(bool state) 
    {
        activeGameObject.SetActive(state);
        SetCooldownState(!state);
    }
    public void SetActivefillImage(float current,float max) 
    {
        fillActiveImage.fillAmount = 1-(current / max) ;
    }
    public void SetCDFillAmount(float current, float max)
    {
        cdFillImage.fillAmount = current/max;
        int unrounded = (int)( 1-(max - current) * 10);
        cdText.text = "" + ((float)unrounded*-1) / 10;
    }
    public void SetCooldownState(bool state) 
    {
        cdFillImage.gameObject.SetActive(state);
    }
}
