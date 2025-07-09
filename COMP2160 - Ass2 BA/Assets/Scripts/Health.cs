using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int currentHealth = 0;
    public int maxHealth = 100;
    public int smokeHealth = 50;
    public int healAmount = 10;

    private int collisionDamage;

    public HealthBar healthBar;
    public ParticleSystem smoke;
    public ParticleSystem explosion;

    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("/GameManager").GetComponent<GameManager>();
        currentHealth = maxHealth;
        smoke.GetComponent<ParticleSystem>().enableEmission = false;
        explosion.GetComponent<ParticleSystem>().enableEmission = false;
    }

    void Update()
    {
        //if currentHealth is less than a certain threshold, smoke will appear
        if(currentHealth <= smokeHealth)
        {
            smoke.GetComponent<ParticleSystem>().enableEmission = true;
        }
        else if(currentHealth > smokeHealth)
        {
            smoke.GetComponent<ParticleSystem>().enableEmission = false;
        }

        if(currentHealth < 0)
        {
            currentHealth = 0;
        }

        if(currentHealth > 100)
        {
            currentHealth = 100;
        }

        //if current health is = 0, explosion will appear
        if(currentHealth == 0)
        {
            smoke.GetComponent<ParticleSystem>().enableEmission = false;
            explosion.GetComponent<ParticleSystem>().enableEmission = true;

            gameManager.Die();
        }
    }

    //on trigger collision that affects the health based on the velocity of a collision when player collides with an obstacle
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 8)
        {
            collisionDamage = (int)collision.impulse.magnitude/20;
            if(collisionDamage > 4)
            {
                DamagePlayer(collisionDamage);
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.layer == 9)
        {
            DamagePlayer(-healAmount);
        }
    }

    public void DamagePlayer(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    public int getCurrentHealth()
    {
        return currentHealth;
    }
}
