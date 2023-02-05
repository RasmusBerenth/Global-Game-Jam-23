using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public bool gameVictory = false;
    private WaterManager waterManagerScript;
    public float timer = 30;
    private void Start()
    {
        waterManagerScript = GameObject.Find("Mushroom").GetComponent<WaterManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waterManagerScript.growNumber == 10)
        {
            gameVictory = true;
        }

        timer -= Time.deltaTime;
        if (timer == 0)
        {
            Debug.Log("Game Over!!!");
        }
    }
}
