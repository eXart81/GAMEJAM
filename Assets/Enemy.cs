using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10;
    [HideInInspector]
    public float speed;
    public float startHealth = 100f;
    private float health;
    public int worth = 5;

    [SerializeField] public Transform targetPoint;

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

    public void Die()
    {
        isDead = true;

        // Utilisez l'instance de VaguesManager pour décrémenter EnemiesAlive
        if (vaguesManager != null)
        {
            vaguesManager.DecrementEnemiesAlive();
        }
        
        if (deathEffect != null)
        {
            GameObject deathParticles = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(deathParticles, 2f);
        }

        GetComponent<NavMeshAgent>().speed = 0;
        var a = GetComponent<Animator>();
        a.SetTrigger("death");
        Invoke("RealDeath", a.GetCurrentAnimatorClipInfo(0).Length);
    }

    public void RealDeath()
    { 
        vaguesManager.GetComponent<PlayerStats>().Money += worth;
        Destroy(gameObject);
    }
}