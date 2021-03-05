using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementConfiner : MonoBehaviour
{
    //map dükdörtgen olacağı için saldım bu kodu çok gerek yok. Box colliderlar ile sınırladım :D


    // [SerializeField] private float PushForce = 50f;
    // Rigidbody2D playerRb;
    // private void Start()
    // {
    //     playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    // }
    // [SerializeField] private S_Vector2 moveDirection;
    // private void OnCollisionExit2D(Collision2D other)
    // {
    //     print("Abi çıktın alandan geri dön.");
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         playerRb.AddForce(moveDirection.Value * PushForce,ForceMode2D.Impulse);
    //         print("Launched Player with a force of: " + moveDirection.Value);
    //     }
    // }
}
