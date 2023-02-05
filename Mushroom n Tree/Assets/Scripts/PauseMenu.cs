using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject resumeButton;
    public GameObject quitButton;

    public GameObject waterMeter;
    public GameObject waterMeter1;
    public GameObject waterMeter2;
    public GameObject waterMeter3;
    public GameObject waterMeter4;
    public GameObject waterMeter5;

    private WaterManager waterManager;

    private void Awake()
    {
        waterManager = GameObject.Find("Mushroom").GetComponent<WaterManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Time.timeScale = 0.0f;
            pauseScreen.SetActive(true);
        }

        if (waterManager.collectedWater == 0)
        {
            waterMeter.SetActive(true);
            waterMeter1.SetActive(false);
            waterMeter2.SetActive(false);
            waterMeter3.SetActive(false);
            waterMeter4.SetActive(false);
            waterMeter5.SetActive(false);
        }

        if (waterManager.collectedWater == 1)
        {
            waterMeter1.SetActive(true);
        }

        if (waterManager.collectedWater == 2)
        {
            waterMeter2.SetActive(true);
        }

        if (waterManager.collectedWater == 3)
        {
            waterMeter3.SetActive(true);
        }

        if (waterManager.collectedWater == 4)
        {
            waterMeter4.SetActive(true);
        }

        if (waterManager.collectedWater == 5)
        {
            waterMeter5.SetActive(true);
        }
    }

    public void Resume()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Exit()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
