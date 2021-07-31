using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int currentHealth, maxHealth;
    public UnityEvent Death;
    
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amt)
    {
        currentHealth = Mathf.Clamp(currentHealth - amt, 0, maxHealth);

        if (currentHealth == 0)
            Death.Invoke();
    }
}
