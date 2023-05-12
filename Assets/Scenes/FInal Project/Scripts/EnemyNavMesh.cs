using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{

    public Transform[] movePosition;
    private NavMeshAgent navAgent;
    public GameObject player;
    public float detectRadius;
    public bool playerDetected;
    public GameObject source;
    private Player playerScript;
    public float patrolSpeed = 2f;
    public float chaseSpeed = 5f;
    private Animator animator;


    void Start()
    {
        playerScript = source.GetComponent<Player>();
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.destination = movePosition[0].position;
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponentInChildren<Animator>();
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
            animator.SetBool("Aware", false);
            navAgent.speed = patrolSpeed;
            animator.SetBool("attack", false);

        }
        else if (playerDetected == true)
        {
            navAgent.destination = player.transform.position;
            animator.SetBool("Aware", true);
            navAgent.speed = chaseSpeed;
            if (Vector3.Distance(player.transform.position, gameObject.transform.position) < 1.5f)
            {
                animator.SetBool("attack", true);
            }
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerScript.TakeDamage(5);
        }
    }

}
