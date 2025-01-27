using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinAndUIController : MonoBehaviour
{
    public GameObject player;

    private CharacterControl controllerScript;
    public GameObject victoryPoPUp;
    private GameObject window;
    

    // Start is called before the first frame update
    private void Start()
    {
        if (victoryPoPUp == null)
        {
            Debug.LogError("No victory pop up found");
            victoryPoPUp = GameObject.Find("VictoryPoPUp");
        }
        
        window = victoryPoPUp.transform.GetChild(0).gameObject;
        window.SetActive(false);
        if (controllerScript == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            controllerScript = player.GetComponent<CharacterControl>();
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeSkin(5);
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeSkin(3);
        }else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeSkin(4);
        }else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeSkin(1);
        }else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ChangeSkin(2);
        }else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            ChangeSkin(0);
        }
    }

    // Update is called once per frame
    public void ChangeSkin(int skinIndex)
    {
        controllerScript.SetSkin(skinIndex);
    }
    
    public void ReloadScene()
    {
        
        string currentSceneName = SceneManager.GetActiveScene().name;
        
        SceneManager.LoadScene(currentSceneName);
    }

    public void goMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void popUpVictory()
    {
        
        window.gameObject.SetActive(true);
    }
}