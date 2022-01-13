using UnityEngine;
 
public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    public float startSpeed = 10f;
    public float health = 100;
    public int damage = 1;
    public int worth = 50;
    public EnemyType type;
    public GameObject deathEffect;
    public Transform prefab;
       
    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
            Die();
    }

    public void Slow(float percentage)
    {
        speed = startSpeed * (1f - percentage);
    }

    private void Start()
    {
        speed = startSpeed;
    }

    private void Die()
    {
        PlayerStats.Money += worth;
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);        
        Destroy(gameObject);
    }
}

public enum EnemyType
{
    Standart = 1,
    Fast = 2,
    Fat = 3
}
