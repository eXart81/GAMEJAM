using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10;
    [HideInInspector]
    public float speed;
    public float startHealth = 100f;
    private float health;
    public int worth = 50;

    public GameObject deathEffect;

    public Image healthbar;

    private bool isDead = false;

    // Ajoutez une référence à l'instance de VaguesManager
    private VaguesManager vaguesManager;

    public void Start()
    {
        speed = startSpeed;
        health = startHealth;

        // Assurez-vous d'obtenir la référence correcte à l'instance de VaguesManager
        vaguesManager = FindObjectOfType<VaguesManager>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        //healthbar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow(float amount)
    {
        speed = startSpeed * (1f - amount);
    }

    private void Die()
    {
        isDead = true;

        PlayerStats.money += worth;

        if(deathEffect != null)
        {
            GameObject deathParticles = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(deathParticles, 2f);
        }

        // Utilisez l'instance de VaguesManager pour décrémenter EnemiesAlive
        if (vaguesManager != null)
        {
            vaguesManager.DecrementEnemiesAlive();
        }

        Destroy(gameObject);
    }
}