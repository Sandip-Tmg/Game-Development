using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class week3PlayerController : MonoBehaviour
{
    public float maxSpeed;
    public float jumpPower;
    public float accelerationSpeed;
    public float inAirAccelerationSpeed;
    public float inAirMaxSpeed;
    Rigidbody2D myrigidbody;
    Animator anim;
    float currentSpeed;
    float upSpeed;
    public Transform animatorTransform;
    public bool amIGrounded;
    public ParticleSystem dust;


    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        myrigidbody = GetComponent<Rigidbody2D>();
        dust.Stop();
    }


    void FixedUpdate()
    {
        currentSpeed = myrigidbody.velocity.x;

        float move = Input.GetAxis("Horizontal");

        if (move < 0)
        {
            animatorTransform.localScale = new Vector3(-1, animatorTransform.localScale.y, animatorTransform.localScale.z);
            dust.Play();
        }
        else if (move > 0)
        {
            animatorTransform.localScale = new Vector3(1, animatorTransform.localScale.y, animatorTransform.localScale.z);
            dust.Play();
        }

        if (move == 0)
        {
            dust.Stop();
        }

        if (Mathf.Abs(currentSpeed) < maxSpeed && amIGrounded == true)
        {
            myrigidbody.AddForce(new Vector2(move * accelerationSpeed, 0));

        }

        if (Mathf.Abs(currentSpeed) < inAirMaxSpeed && amIGrounded == false)
        {
            myrigidbody.AddForce(new Vector2(move * inAirAccelerationSpeed, 0));
        }

        anim.SetFloat("speed", (Mathf.Abs(currentSpeed + move)));



        float moveup = Input.GetAxis("Vertical");

        upSpeed = myrigidbody.velocity.y;
        if (Input.GetKey("space") && myrigidbody.velocity.y < 0.1 && myrigidbody.velocity.y > -0.1 && amIGrounded == true || moveup > 0.1 && myrigidbody.velocity.y < 0.1 && myrigidbody.velocity.y > -0.1 && amIGrounded == true) //checks if Spacebar OR up button is being pressed, and if the rigidbody is not already moving up/down, and if the player is standing on something
        {
            dust.Stop();
            myrigidbody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        }


        anim.SetFloat("verticalSpeed", (upSpeed + moveup));

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player" && collision.isTrigger == false)
        {
            amIGrounded = true;
            anim.SetBool("amIGrounded", true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player" && collision.isTrigger == false)
        {
            amIGrounded = false;
            anim.SetBool("amIGrounded", false);
        }

    }
}
