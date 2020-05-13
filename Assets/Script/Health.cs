using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 6;
    private int currentHealth = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    void SetDamage(int damage)
    {
        currentHealth -= damage;
        HealthIndicator.Instance.UpdateVidaUI(currentHealth);
        CheckDeath();
    }

    public void SetHeal(int heal)
    {
        currentHealth += heal;
    }

    public int GetHeal()
    {
        return currentHealth;
    }

    void CheckDeath()
    {
        if (currentHealth <= 0)
        {
            GameOverMenu.isGameOver = true;
            gameObject.SetActive(false);
        }
    }
}
