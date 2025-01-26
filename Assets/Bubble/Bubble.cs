using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private int health; 
    private int counter = 0;
    private Animator animator; 
    
    void Start()
    {
        animator = GetComponent<Animator>(); 
        animator.SetInteger("health", health); // Başlangıçta health değerini eşitle
    }

    void Update()
    {
        UpdateAnimationState();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(gameObject.tag))
        {
            Debug.Log("We are the same element!");
            health++;
            animator.SetInteger("health", health);
            
            if (counter == 10) 
            {
                Debug.Log("You won the game!");
            }
        }
        else
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        health--;
        Debug.Log("Health: " + health);
        animator.SetInteger("health", health); // Animator'daki health güncelleniyor

        if (health <= 0)
        {
            Debug.Log("Bubble destroyed!");
            Destroy(gameObject, 2f); 
        }
    }

    private void UpdateAnimationState()
    {
        animator.SetInteger("health", health); // Animator parametresini sürekli güncelle
    }
}