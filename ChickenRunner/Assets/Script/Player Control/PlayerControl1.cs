using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl1 : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardSpeed, reverseSpeed, turnSpeed;
    private float moveInput, turnInput;
    void Start()
    {
        rb.transform.parent = null;
    }

    void Update()
    {
        //forward and backward movement
        moveInput = Input.GetAxis("Vertical");
        moveInput *= moveInput > 0 ? forwardSpeed : reverseSpeed;

        //left and right movement
        turnInput = Input.GetAxis("Horizontal");
        float newRotation = turnInput * turnSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        transform.Rotate(0, newRotation, 0, Space.World);

        //set the sphere with the car
        transform.position = rb.transform.position;

    }
    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
    }
}
