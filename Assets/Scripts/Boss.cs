using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health = 100f;

    public float MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
    public float Health { get { return health; } set { health = value; } }

    public static Boss instance;
    private void Start()
    {
        instance = this;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
    private void Update()
    {
        Die();
    }
    void Die()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
