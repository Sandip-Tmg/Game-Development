using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class boss : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent navAgent;
    public GameObject player;
    public float detectRadius;
    public bool playerDetected;
    private Animator animator;
    public GameObject source;
    private Player playerScript;


    void Start()
    {
        navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponentInChildren<Animator>();
        playerScript = source.GetComponent<Player>();
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
            animator.SetBool("playerDetected", false);
            animator.SetBool("attack", false);
        }
        else if (playerDetected == true)
        {
            navAgent.destination = player.transform.position;
            animator.SetBool("playerDetected", true);
            if(Vector3.Distance(player.transform.position, gameObject.transform.position) < 6f ){
                animator.SetBool("attack", true);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Object Detected");
            playerScript.TakeDamage(5);
        }
   
    }

}
