using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawners;

    [SerializeField] private GameObject[] elementals;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(Spawn());
    }


    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            var spawnerChosen = Random.Range(0, spawners.Length);
            var elementChosen = Random.Range(0, elementals.Length);
            Instantiate(elementals[elementChosen], spawners[spawnerChosen].transform.position, Quaternion.identity);
        }
    }


    private void getRandomInt()
    {
        var random = Random.Range(0, spawners.Length);
    }
}