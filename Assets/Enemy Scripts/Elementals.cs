using UnityEngine;

public class Elementals : MonoBehaviour
{
    private GameObject bubble;
    private Bubble bubbleScript; // Zıplama kontrolü
    private float gravity = -9.81f; // Yerçekimi

    private bool JUMP = false;
    private readonly float jumpForce = 10f; // Zıplama kuvveti
    private readonly float moveSpeed = 5f; // Hareket hızı
    private Rigidbody2D rb; // Rigidbody2D bileşeni

    private void Start()
    {
        bubble = GameObject.Find("Bubble");
        if (bubble == null)
        {
        }

        bubbleScript = bubble.GetComponent<Bubble>();
        // Rigidbody2D bileşenini al
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BubbleTrigger")) rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}