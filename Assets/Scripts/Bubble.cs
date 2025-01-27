using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class Bubble : MonoBehaviour
{
    [FormerlySerializedAs("health")] [SerializeField] private int bubblHealth;
    private Animator animator;
    private int counter = 0;
    private SceneLoader sceneLoader;
    private SkinAndUIController skinAndUIController;
    private GameObject skinAndUIControllerObject;
    private GameObject spawners;
    private string[] enemyElementalTags = new string[5];

    private void Start()
    {
        getEnemyElementalTags();
        foreach (string element in enemyElementalTags)
        {
            Debug.Log(element);
        }
        spawners = GameObject.Find("Spawners");
        skinAndUIControllerObject = GameObject.Find("SkinAndUIController");
        skinAndUIController = skinAndUIControllerObject.GetComponent<SkinAndUIController>();
        animator = GetComponent<Animator>();
        sceneLoader = GetComponent<SceneLoader>();
        animator.SetInteger("health", bubblHealth); // Başlangıçta health değerini eşitle
    }

    private void Update()
    {
        UpdateAnimationState();
    }

    private bool isTakingDamage = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isTakingDamage) return; // Eğer zaten hasar alıyorsa, tekrar hasar alma.

        if (other.gameObject.CompareTag(gameObject.tag))
        {
            bubblHealth++;
            Debug.Log("Health: " + bubblHealth);
        
            animator.SetInteger("health", bubblHealth);
            if (bubblHealth >= 10)
            {
                skinAndUIController.popUpVictory();
                spawners.SetActive(false);
            }
        }
        else
        {
            foreach (string element in enemyElementalTags)
            {
                if (other.gameObject.CompareTag(element))
                {
                    Debug.Log(other.gameObject.name);
                    StartCoroutine(TakeDamageWithCooldown()); // Cooldown sistemi ekledik
                    break;
                }
            }
        }
    }

    private IEnumerator TakeDamageWithCooldown()
    {
        isTakingDamage = true;
        TakeDamage();
        yield return new WaitForSeconds(0.1f); // 0.1 saniye cooldown süresi
        isTakingDamage = false;
    }

    public void TakeDamage()
    {
        Debug.Log("?");
        bubblHealth = bubblHealth - 1;
        Debug.Log("Health: " + bubblHealth);
        animator.SetInteger("health", bubblHealth); // Animator'daki health güncelleniyor

        if (bubblHealth <= 0)
        {
            Debug.Log("Bubble destroyed!");
            StartCoroutine(GameOver());
        }
    }

    private void UpdateAnimationState()
    {
        animator.SetInteger("health", bubblHealth); // Animator parametresini sürekli güncelle
    }
    

    private IEnumerator GameOver()
    {
        
        yield return new WaitForSeconds(2.5f);
        sceneLoader.MainMenuLoader();
    }

    private void getEnemyElementalTags()
    {
        int counter = 0;
        string[] allElementalTags = new string[6];
        allElementalTags[0] = "air";
        allElementalTags[1] = "fire";
        allElementalTags[2] = "water";
        allElementalTags[3] = "earth";
        allElementalTags[4] = "darkness";
        allElementalTags[5] = "light";
        foreach (string element in allElementalTags)
        {
            if (!gameObject.CompareTag(element))
            {
                enemyElementalTags[counter] = element;
                counter++;
            }
        }
    }
}