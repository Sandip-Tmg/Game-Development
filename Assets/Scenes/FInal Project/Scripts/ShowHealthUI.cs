using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHealthUI : MonoBehaviour
{
    private Camera playerFpsCam;

    private void Start()
    {
        playerFpsCam = Camera.main;
    }

    private void FixedUpdate()
    {
        FaceHeathBarAtPlayer();
    }

    private void FaceHeathBarAtPlayer()
    {
        transform.LookAt(transform.position + playerFpsCam.transform.rotation * Vector3.forward, playerFpsCam.transform.rotation * Vector3.up);
    }


}
