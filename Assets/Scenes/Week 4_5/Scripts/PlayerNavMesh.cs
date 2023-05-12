using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerNavMesh : MonoBehaviour
{
    public Transform[] movePosition;
    private NavMeshAgent navAgent;
    public GameObject player;
    public float detectRadius;
    public bool playerDetected;


    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.destination = movePosition[0].position;
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= detectRadius)
        {
            playerDetected = true;
        }
        else
        {
            playerDetected = false;
        }

        if (navAgent.remainingDistance < 0.5f && playerDetected == false)
        {
            navAgent.destination = movePosition[Random.Range(0, movePosition.Length)].position;
        }
        else if(playerDetected == true)
        {
            navAgent.destination = player.transform.position;
        }
    }
}
