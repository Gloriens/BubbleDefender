using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManagerOnScenes : MonoBehaviour
{
    GameObject musicManager;
    AudioSource audioSource;
    [SerializeField] private Image cross;
    

    void Start()
    {
        if (cross == null)
        {
            cross = GetComponentInChildren<Image>(); // Butonun içindeki Image bileşenini otomatik bul
        }

        if (cross != null)
        {
            cross.enabled = false;
        }

        musicManager = GameObject.Find("MusicManager");
        if (musicManager != null)
        {
            audioSource = musicManager.GetComponent<AudioSource>();
        }
    }

    public void ToggleMusic()
    {
        if (audioSource != null)
        {
            if (audioSource.isPlaying)
            {
                if (cross != null) cross.enabled = true;
                audioSource.Pause();
            }
            else
            {
                if (cross != null) cross.enabled = false;
                audioSource.Play();
            }
        }
    }
}