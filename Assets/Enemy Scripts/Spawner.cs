using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawners;
    [SerializeField] private GameObject[] elementals;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }



    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            int spawnerChosen = Random.Range(0, spawners.Length);
            int elementChosen = Random.Range(0, elementals.Length);
            Instantiate(elementals[elementChosen], spawners[spawnerChosen].transform.position, Quaternion.identity);
        }
        
    }



    private void getRandomInt()
    {
        int random = Random.Range(0, spawners.Length);
    }
}
