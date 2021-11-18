using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : CharacterController
{
    [System.NonSerialized]
    public GameObject container;

    [System.NonSerialized]
    public CharacterDash charDash;
    PlayerActions actions;
   

    private void Awake()
    {
        base.Awake();
        actions = new PlayerActions();

        actions.PlayerControls.Enable();
        actions.PlayerControls.Dash.performed += Dash_performed;
        actions.PlayerControls.ChangeDashRight.performed += ChangeDashRight;
        actions.PlayerControls.ChangeDashLeft.performed += ChangeDashLeft;
        //actions.PlayerControls.Dash.canceled += Move_canceled;
    }


    void Start()
    {
        base.Start();
        charDash = GetComponent<CharacterDash>();
        container = transform.Find("Dashes").gameObject;
        anim = transform.Find("Animations").GetComponent<PlayerAnim>();
    }
    private void FixedUpdate()
    {
       
    }
    void Update() 
     {
        base.Update();

        if (!charDash.isDashing) 
        {
            movement.Movement();
        }

      

    }

    private void ChangeDashRight(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (context.performed) { 
            charDash.ChangeDash(1);
        }
    }
    private void ChangeDashLeft(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            charDash.ChangeDash(-1);
        }
    }

    private void Dash_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (charDash.dashes.Count > 0 && context.performed)
        {
            charDash.Dash();
        }
    }

}
