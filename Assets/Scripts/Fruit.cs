using System;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Blade blade))
        {
            CreateFluidSlice();
        }
    }

    private void CreateFluidSlice()
    {
        Destroy(gameObject);
    }
}
