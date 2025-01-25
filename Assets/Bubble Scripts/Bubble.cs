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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("air"))
        {
            Debug.Log("I am air");
            counter++;
            if (health == 5)
            {
                Debug.Log("You won the game");
            }
            
        }
        else
        {
            takeDamage();
            Destroy(other.gameObject);
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
