using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    private Vector3 velocity;
    private CharacterController characterController;
    public float playerSpeed = 5f;
    public bool isGrounded;
    private float gravity = -9.8f;
    public float jumpForce = 1.2f;
    public bool sprinting = false;
    public bool shoot;
    public static int playerHealth = 100;
    public bool isGameOver;
    public TextMeshProUGUI playerHealthStatusText;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthStatusText.text = "Health: " + playerHealth;
        isGrounded = characterController.isGrounded;
        if (isGameOver)
        {
            playerHealthStatusText.text = "Game Over";
        }
    }

    // function to move the player around the terrain or level
    public void move(Vector2 input)
    {
        Vector3 direction = Vector3.zero;
        direction.x = input.x;
        direction.z = input.y;
        characterController.Move(transform.TransformDirection(direction) * playerSpeed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        if(isGrounded && velocity.y< 0)
        {
            velocity.y = -2;
        }
        characterController.Move(velocity * Time.deltaTime);

    }

    // function to jump if the player is Grounded
    public void jump()
    {
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -3.0f * gravity);
        }
    }

    public void sprint()
    {
        sprinting = !sprinting;
        if (sprinting)
        {
            playerSpeed = 8;
        }
        else
        {
            playerSpeed = 5;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        playerHealth -= damageAmount;
        if(playerHealth <= 0)
        {
            isGameOver = true;
        }
    }
}
