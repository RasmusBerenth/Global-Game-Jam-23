using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterManager : MonoBehaviour
{
    public float collectedWater;
    private float offset = 0.5f;
    private float timer = 30f;

    public GameObject tree;
    public GameObject[] roots;

    public int growNumber = 0;
    private int i = 0;

    private Renderer transparent;

    private void Start()
    {
        transparent = GetComponent<Renderer>();
    }

    private void Uppdate()
    {
        timer -= Time.deltaTime;
        if (timer == 0)
        {
            Debug.Log("Game Over!!!");
        }
    }

    private void OnParticleCollision()
    {
        collectedWater += 1;
        Debug.Log($"Hit!, {collectedWater}");
        transparent.material.color = new Color(12, 231, 210);
        ColorChange();
        transparent.material.color = new Color(19, 125, 102);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal") && collectedWater > 0)
        {
            timer = 30f;
            tree.transform.localScale = new Vector3(tree.transform.localScale.x - offset + collectedWater, tree.transform.localScale.y - offset + collectedWater, tree.transform.localScale.z - offset + collectedWater);
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
        return new Vector3(Random.Range(-40, 40), 0, Random.Range(-60, 60));
    }

    private IEnumerator ColorChange()
    {
        yield return new WaitForSeconds(2);
    }
}
