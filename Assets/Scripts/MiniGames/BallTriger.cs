using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTriger : MonoBehaviour
{
    public float damage = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController col = collision.gameObject.GetComponent<PlayerController>();
            col.Health -= damage;
            Debug.Log("ss");

        }
    }
}
