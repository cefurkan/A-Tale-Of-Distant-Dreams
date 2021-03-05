using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb2D;
    public PhysicsMaterial2D phyMat2D;
    public float speed;
    void Start()
    {

        speed = 2f;
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(speed, speed);
    }
    private void Update()
    {
        float x = rb2D.velocity.x / Mathf.Abs(rb2D.velocity.x) * speed;
        float y = rb2D.velocity.y / Mathf.Abs(rb2D.velocity.y) * speed;
        rb2D.velocity = new Vector2(x, y);
    }

}
