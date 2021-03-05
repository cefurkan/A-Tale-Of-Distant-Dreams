using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlayArea : MonoBehaviour
{
    public float damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
       PlayerMovement col = collision.gameObject.GetComponent<PlayerMovement>();
        col.Health -= damage;
    }
}
