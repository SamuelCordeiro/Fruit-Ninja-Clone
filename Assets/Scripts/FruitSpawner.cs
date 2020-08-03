using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    //public GameObject fruit;
    public GameObject[] items;
    public Transform[] spawnPoints;
    public float minSpawnDelay = 0.01f;
    public float maxSpawnDelay = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {}

    IEnumerator Spawn()
    {
        while(true)
        {
            float timer = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(1f);
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            int itemIndex = Random.Range(0, items.Length);
            GameObject spawnedItem = Instantiate(items[itemIndex], spawnPoint.position, spawnPoint.rotation);
            Destroy(spawnedItem, 5f);
        }
    }
}
