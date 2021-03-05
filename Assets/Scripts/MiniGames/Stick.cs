using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float damage = 10f;

    void Start()
    {
        Invoke("DestroyStick", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    void DestroyStick()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
          PlayerController col =  collision.gameObject.GetComponent<PlayerController>();
            col.Health -= damage;
        }
    }
}
