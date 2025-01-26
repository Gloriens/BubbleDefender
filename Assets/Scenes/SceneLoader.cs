using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    public void Airloader()
    {
        SceneManager.LoadScene("AirScene");
    }
    public void Earthloader()
    {
        SceneManager.LoadScene("EarthScene");
    }
    public void Darknessloader()
    {
        SceneManager.LoadScene("DarknessScene");
    }
    public void Lightloader()
    {
        SceneManager.LoadScene("LightScene");
    }
    public void Waterloader()
    {
        SceneManager.LoadScene("WaterScene");
    }
    public void Fireloader()
    {
        SceneManager.LoadScene("FireScene");
    }
}
