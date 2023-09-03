using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class FruitSpawner : MonoBehaviour
{
    private const int SPAWN_FRUIT_INTEVAL = 2;
    private const int SCREEN_TOP_Y = 5;
    private const int RANDOM_X_MIN = -10;
    private const int RANDOM_X_MAX = 11;
    private float force = 12f;

    [SerializeField] private GameObject fruitPrefab;

    private void Start()
    {
        StartCoroutine(SpawnFruitCoroutine());
    }

    private IEnumerator SpawnFruitCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(SPAWN_FRUIT_INTEVAL);
            SpawnFruit();
            int random = Random.Range(0, 2);
            //if (random == 1) 
        }
    }

    private void SpawnFruit()
    {
        GameObject spawnedFruitObject = Spawner.Spawn(fruitPrefab, transform.position, Random.rotation);
        Rigidbody fruitRigidbody = spawnedFruitObject.GetComponent<Rigidbody>();
        float randomX = Random.Range(transform.position.x - 1f, transform.position.x + 1f);
        Vector3 randomUpVector = new Vector3(randomX, SCREEN_TOP_Y);
        Vector3 forceDirection = randomUpVector - transform.position;
        fruitRigidbody.AddForce(forceDirection * force);
    }
}
