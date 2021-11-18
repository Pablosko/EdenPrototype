using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerMovement : CharacterMovement
{
    // Start is called before the first frame update
    public Vector2 lastFacingDir;
    [System.NonSerialized]
    public PlayerController player;
    private void Awake()
    {
        base.Awake();
        player = character.GetComponent<PlayerController>();
        PlayerActions actions = new PlayerActions();
        actions.PlayerControls.Enable();
        actions.PlayerControls.Move.performed += Move_performed;
        actions.PlayerControls.Move.canceled += Move_canceled;
    }

    void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if(character.rb2d.velocity.magnitude > 0.2)
            lastFacingDir = character.rb2d.velocity;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (character != null)
        {
            if (!player.charDash.isDashing)
            {
                character.rb2d.AddForce(direction * character.stats.aceleration.Value * Time.fixedDeltaTime,ForceMode2D.Force);
                character.rb2d.velocity = Vector2.ClampMagnitude(character.rb2d.velocity, character.stats.maxSpeed.Value);
            }
        }

    }

    private void Move_canceled(InputAction.CallbackContext obj)
    {
        if(canMove)
            SetDirection(Vector2.zero);
    }

    private void Move_performed(InputAction.CallbackContext context)
    {
        if (!player.charDash.isDashing && canMove)
        {
            SetDirectionAndNotNormalize(context.ReadValue<Vector2>());
        }
    }

    void Rumba()
    {
        /*Vector2 caca = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = (caca - (Vector2)transform.position).normalized;
        inputDir = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
            inputDir = dir.normalized;
        */
    }

}
