using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 70)
        {
            transform.position = new Vector3(70, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -65)
        {
            transform.position = new Vector3(-65, transform.position.y, transform.position.z);
        }

        if (transform.position.z > 100)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 100);
        }

        if (transform.position.z < -90)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -90);
        }
    }
}
