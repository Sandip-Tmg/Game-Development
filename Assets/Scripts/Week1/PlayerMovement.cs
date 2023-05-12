using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpSpeed = 10f;
    public float distToGround = 0.5f;
    
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody>();
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGround);
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);

    }

   
}
