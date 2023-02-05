using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterManager : MonoBehaviour
{
    public float collectedWater;
    //private float offset = 1f;
    private float growScale;

    public GameObject tree;
    public GameObject[] roots;

    public int growNumber = 0;
    private int i = 0;

    private Renderer transparent;

    private AudioSource soundEffect;
    public AudioClip catchRain;
    public AudioClip wateringTree;

    private GameOver gameOver;

    private void Start()
    {
        transparent = GetComponent<Renderer>();
        soundEffect = GetComponent<AudioSource>();
        gameOver = GameObject.Find("UImanager").GetComponent<GameOver>();
    }

    private void Update()
    {
        growScale = collectedWater * 0.8f;
    }

    private void OnParticleCollision()
    {
        collectedWater += 1;
        Debug.Log($"Hit!, {collectedWater}");
        soundEffect.PlayOneShot(catchRain, 1f);

        ColorChange();
        transparent.material.color = new Color(19, 125, 102, 255);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal") && collectedWater > 0)
        {
            soundEffect.PlayOneShot(wateringTree, 0.5f);
            //gameOver.timer = 30f;
            tree.transform.localScale = new Vector3(tree.transform.localScale.x + growScale, tree.transform.localScale.y + growScale, tree.transform.localScale.z + growScale);
            collectedWater = 0;
            growNumber++;
            SpawRoots();
        }
    }

    public void SpawRoots()
    {
        while (i < 5)
        {
            Instantiate(roots[Random.Range(0, 2)], GenerateRootPosition(), roots[1].transform.rotation);
            i++;
        }

        i = 0;
    }

    public Vector3 GenerateRootPosition()
    {
        return new Vector3(Random.Range(-50, 50), 0, Random.Range(-60, 60));
    }

    private IEnumerator ColorChange()
    {
        transparent.material.color = new Color(30, 225, 210, 230);
        yield return new WaitForSeconds(2);
    }
}
