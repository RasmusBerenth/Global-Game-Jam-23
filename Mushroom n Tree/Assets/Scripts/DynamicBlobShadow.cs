using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBlobShadow : MonoBehaviour
{

    public float offset = 0.1f;
    public LayerMask mask;

    // Update is called once per frame
    private void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        bool success = Physics.Raycast(ray, out RaycastHit hit, 1000f, mask);

        if (success)
        {
            transform.position = hit.point + Vector3.up * offset;
        }

        // Use this if rotation is wrong
        //transform.eulerAngles = Vector3.left * 90;
    }
}
