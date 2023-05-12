using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossTarget : MonoBehaviour
{
    private float health = 1000f;
    private float maxHealth = 1000f;
    public Slider healthStatusBar;
   

    private void Start()
    {
        healthStatusBar.value = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
        SetHealthBar();
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void SetHealthBar()
    {   
        healthStatusBar.value = ((float)health / (float)maxHealth) * 1000;
    }
}
