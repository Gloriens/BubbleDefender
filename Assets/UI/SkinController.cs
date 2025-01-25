using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinController : MonoBehaviour
{
    public GameObject player;
    private CharacterControl controllerScript;
    // Start is called before the first frame update
    void Start()
    {
        if (controllerScript == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            controllerScript = player.GetComponent<CharacterControl>();
        }
    }

    // Update is called once per frame
    public void ChangeSkin(int skinIndex)
    {
        controllerScript.SetSkin(skinIndex);
    }
}
