using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    public float rotationSpeed = 500;
    private float horizontalInput;
    private float verticalInput;

    public Animator skipping;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        WaitForAnim();
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        moveDirection.Normalize();
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        if (moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection;
        }
    }

    private IEnumerator WaitForAnim()
    {
        yield return new WaitForSeconds(1);
        skipping.SetTrigger("Moving");

    }
}
