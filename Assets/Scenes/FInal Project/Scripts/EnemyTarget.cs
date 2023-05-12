using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTarget : MonoBehaviour
{
    private float health = 100f;
    private float maxHealth = 100f;
    public Slider healthStatusBar;
   

    private void Start()
    {
        healthStatusBar.value = ((float)health / (float)maxHealth) * 100;
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
        healthStatusBar.value = ((float)health / (float)maxHealth) * 100;
    }

}
