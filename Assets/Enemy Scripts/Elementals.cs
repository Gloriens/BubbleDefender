using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elementals : MonoBehaviour
{
    private float moveSpeed = 5f; // Hareket hızı
    private float jumpForce = 10f; // Zıplama kuvveti
    private float gravity = -9.81f; // Yerçekimi
    private Rigidbody2D rb; // Rigidbody2D bileşeni

    private bool JUMP= false; // Zıplama kontrolü

    void Start()
    {
        // Rigidbody2D bileşenini al
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y); // Yalnızca X ekseninde hareket ettir
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BubbleTrigger"))
        {

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
           
        }
    }
    
}
