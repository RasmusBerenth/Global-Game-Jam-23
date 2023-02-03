using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterManager : MonoBehaviour
{
    public float collectedWater;
    public bool hasWater = false;

    private void OnParticleCollision()
    {
        collectedWater += 1;
        Debug.Log($"{collectedWater}");

    }

    private void Update()
    {
        if (collectedWater == 3)
        {
            hasWater = true;
        }
    }
}
