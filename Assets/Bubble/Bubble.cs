using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private int health; 
    private int counter = 0;
    private Animator animator;
    private SceneLoader sceneLoader;
    
    void Start()
    {
        animator = GetComponent<Animator>(); 
        sceneLoader = GetComponent<SceneLoader>();
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
            StartCoroutine(DestroyAfterTime(other.gameObject));

            
            
        }
        else
        {
            if (!other.gameObject.CompareTag("Player"))
            {
                Animator anim = other.gameObject.GetComponent<Animator>();
                anim.SetTrigger("isDestroyed");
                StartCoroutine(DestroyAfterTime(other.gameObject));
                TakeDamage();
                
            }
            
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
            StartCoroutine(GameOver());

        }
    }

    private void UpdateAnimationState()
    {
        animator.SetInteger("health", health); // Animator parametresini sürekli güncelle
    }
    
    private IEnumerator DestroyAfterTime(GameObject obj)
    {
        // Wait for 0.8 seconds
        yield return new WaitForSeconds(0.5f);
    
        // Destroy the object after the delay
        Destroy(obj);
    }


    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.9f);
        sceneLoader.MainMenuLoader();
    }
}