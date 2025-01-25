using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private int health;
    private int counter;
   
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag(gameObject.tag))
        {
            Debug.Log("We are the same element!");
            counter++;
            if (counter == 5)
            {
                Debug.Log("You won the game");
            }
            
        }else if (other.CompareTag("Player")!)
        {
            Debug.Log("girdi");
        }
    }

    public void takeDamage()
    {
        health--;
        Debug.Log(health);
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
