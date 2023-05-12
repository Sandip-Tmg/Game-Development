using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float objectForce = 30f;
    public float rateOfFire = 15f;
    private float nextFireTime = 0f;

    public Camera camera;
    public ParticleSystem muzzleFlash;
    public GameObject gunEffect;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / rateOfFire; // if our fire rate is 4 that we will shoot in interval of 0.25 seconds
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hitInfo; // variable to store the hit information 
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hitInfo, range))
        {
            Debug.Log(hitInfo.transform.name);
            EnemyTarget enemyTarget = hitInfo.transform.GetComponent<EnemyTarget>();
            BossTarget bossTarget = hitInfo.transform.GetComponent<BossTarget>();
            if(enemyTarget != null )
            {
                enemyTarget.TakeDamage(damage);
            }else if(bossTarget != null)
            {
                bossTarget.TakeDamage(damage);
            }

            GameObject impact = Instantiate(gunEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(impact, 1.5f);

        }
    }
}
