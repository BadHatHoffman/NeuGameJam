using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int currentHealth, maxHealth;
    public UnityEvent Death;
    public Slider health;
    
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amt)
    {
        currentHealth = Mathf.Clamp(currentHealth - amt, 0, maxHealth);

        if(health)
        {
            health.value = (currentHealth / maxHealth);
        }

        if (currentHealth == 0)
            Death.Invoke();
    }

    public void AddMaxHealth(int amt)
    {
        maxHealth += amt;
        currentHealth = maxHealth;
    }
}
