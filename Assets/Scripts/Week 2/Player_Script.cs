using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    Rigidbody2D rb;
    public float maxSpeed;
    public float acceleration;
    public float jumpForce;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector2(acceleration * maxSpeed, 0));

        // code to jump the player
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerStay2D(Collider2D collision) // needs a trigger to work 
    {
        if (collision.gameObject.tag != "Player" && collision.isTrigger == false)
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player" && collision.isTrigger == false)
        {
            isGrounded = false;
        }

    }


}
