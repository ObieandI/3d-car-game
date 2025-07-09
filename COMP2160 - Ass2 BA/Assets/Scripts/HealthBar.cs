using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public Health carHealth;

    void Start()
    {
        carHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = carHealth.maxHealth;
        healthBar.value = carHealth.maxHealth;
    }

    public void SetHealth(int health)
    {
        healthBar.value = health;
    }
}
