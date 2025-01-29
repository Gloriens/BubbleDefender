using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Scene değişse bile yok olmasın
            audioSource = GetComponent<AudioSource>(); 
            audioSource.Play(); // Müziği başlat
        }
        else
        {
            Destroy(gameObject); // Eğer zaten varsa, yeni oluşanı yok et
        }
    }

   
}
