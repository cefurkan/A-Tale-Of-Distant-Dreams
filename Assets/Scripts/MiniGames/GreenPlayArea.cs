using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlayArea : MonoBehaviour
{
    public float damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
       PlayerController col = collision.gameObject.GetComponent<PlayerController>();
        col.Health -= damage;
    }
}
