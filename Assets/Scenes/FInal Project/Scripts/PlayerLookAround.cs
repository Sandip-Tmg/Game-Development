using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAround : MonoBehaviour
{
    // required properties
    public Camera camera;
    private float horizontalRotation = 0f;
    public float horizontalSensitivity = 30f;
    public float verticalSensitivity = 30f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // function to look up down left and right with mouse movement
    public void lookAround(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        // rotation of camera for up and down 
        horizontalRotation -= (mouseY * Time.deltaTime) * verticalSensitivity;
        horizontalRotation = Mathf.Clamp(horizontalRotation, -90f, 90f);
        camera.transform.localRotation = Quaternion.Euler(horizontalRotation, 0, 0);

        // rotation of camera for left and right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * horizontalSensitivity);
    }
}
