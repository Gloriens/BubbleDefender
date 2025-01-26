using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private int health = 10; 
    private int counter = 0;
    private Animator animator; 
    
    
    void Start()
    {
        animator = GetComponent<Animator>(); 
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
            counter++;
            
            if (counter == 10) 
            {
                animator.SetTrigger("Happy");
                Debug.Log("You won the game!");
            }
        }
    }

    public void TakeDamage()
    {
        health--;
        Debug.Log("Health: " + health);

        if (health <= 0)
        {
            Debug.Log("Bubble destroyed!");
            animator.SetTrigger("Death");
            Destroy(gameObject, 1f); 
        }
    }

    private void UpdateAnimationState()
    {
        if (health <= 2)
        {
            animator.SetTrigger("Death");
        }
        else if (health <= 4)
        {
            animator.SetTrigger("Cry");
        }
        else if (health <= 6)
        {
            animator.SetTrigger("Sad");
        }
        else if (health <= 8)
        {
            animator.SetTrigger("Idle");
        }
    }
}
