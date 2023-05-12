using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    public GameObject door;

    public float maxOpen = 10f;
    public float minClose = 0.1f;
    public float doorSpeed = 10f;
    bool isPlayerOnSensor;
    bool doorOpen;
    // Start is called before the first frame update
    void Start()
    {
        isPlayerOnSensor = false;
        doorOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerOnSensor)
        {
            if(door.transform.position.y < maxOpen)
            {
                door.transform.Translate(0f, doorSpeed * Time.deltaTime, 0f);
            }
            else
            {
                if(door.transform.position.y > minClose)
                {
                    door.transform.Translate(0f, -doorSpeed * Time.deltaTime, 0f);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Debug.Log("Player Tag: "+collider.gameObject.tag);
            isPlayerOnSensor = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            isPlayerOnSensor = false;
        }
    }
}
