using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Fruit : MonoBehaviour
{
    private const int MINIMUM_EXPLOSION_FORCE = 500;
    private const int MAXIMUM_EXPLOSION_FORCE = 1000;

    private float explosionRadius = 5f;

    [SerializeField] private GameObject slicedFruitPrefab;
    [SerializeField] private Renderer fruitRenderer;

    private void Awake()
    {
        fruitRenderer.material.color =
            new Color(
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f));
    }

    public void CreateFluidSlice()
    {
        GameObject spawnedSlicedFruit = Spawner.Spawn(slicedFruitPrefab, transform.position, Quaternion.identity);
        Rigidbody[] slicedFruitRigidbodies = spawnedSlicedFruit.GetComponentsInChildren<Rigidbody>();

        foreach (var rigidbody in slicedFruitRigidbodies)
        {
            rigidbody.rotation = Random.rotation;
            int randomExplosionForce = Random.Range(MINIMUM_EXPLOSION_FORCE, MAXIMUM_EXPLOSION_FORCE);
            rigidbody.AddExplosionForce(
                randomExplosionForce, transform.position, explosionRadius);

            rigidbody.gameObject.GetComponent<Renderer>().material.color = fruitRenderer.material.color;

        }
    }
}
