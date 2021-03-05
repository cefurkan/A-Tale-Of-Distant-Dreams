using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;

    PlayerController player;
    
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Boss"))
        {
           Boss boss = other.gameObject.GetComponent<Boss>();
            boss.TakeDamage(damage);
            Destroy(gameObject);
                
        }
        if (other.gameObject.CompareTag("Cendere"))
        {
            player.TakeDamage(damage);
            Destroy(gameObject);

        }
    }
}
