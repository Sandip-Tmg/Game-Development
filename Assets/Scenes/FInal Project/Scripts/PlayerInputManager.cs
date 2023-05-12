using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    // getting the player action object from Input Action of the player we created
    private PlayerAction playerAction;
    private PlayerAction.OnGroundActions onGround;

    private Player playerMovement;
    private PlayerLookAround playerLook;
    // Start is called before the first frame update
    void Awake()
    {
        playerAction = new PlayerAction();
        onGround = playerAction.OnGround;
        playerMovement = GetComponent<Player>();
        playerLook = GetComponent<PlayerLookAround>();
        onGround.Jump.performed += crx => playerMovement.jump();
        onGround.Sprint.performed += crx => playerMovement.sprint();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // trigger the PlayerAction Input System with the defined object scripts ie.Player and PlayerLookAround
        playerMovement.move(onGround.PlayerMovement.ReadValue<Vector2>());
        playerLook.lookAround(onGround.LookAround.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onGround.Enable();
    }

    private void OnDisable()
    {
        onGround.Disable();
    }
}
