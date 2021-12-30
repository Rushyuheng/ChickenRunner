using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl2 : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardSpeed, reverseSpeed, turnSpeed;
    public bool isGrounded;
    public LayerMask ground;
    private float moveInput, turnInput;
    private int itemIndex = 0;
    public PlayerHUD player2HUD;

    bool Run = false;
    Animator animator;

    void Start()
    {
        rb.transform.parent = null;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //forward and backward movement
        moveInput = Input.GetAxis("Vertical2");
        moveInput *= moveInput > 0 ? forwardSpeed : reverseSpeed;

        //left and right movement
        turnInput = Input.GetAxis("Horizontal2");
        float newRotation = turnInput * turnSpeed * Time.deltaTime * Input.GetAxis("Vertical2");
        transform.Rotate(0, newRotation, 0, Space.World);


        //set the sphere with the car
        transform.position = rb.transform.position;

        //check press key for run animations
        Run = false;
        if (Input.GetKey(KeyCode.UpArrow)) Run = true;
        animator.SetBool("Run", Run);
    }
    private void FixedUpdate()
    {
        RaycastHit hit;
        isGrounded = Physics.Raycast(transform.position, -transform.up, out hit, 1f, ground);
        if (isGrounded)
        {
            rb.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
        }
        else
        {
            rb.AddForce(transform.up * -100f);
        }
    }
    public void GetItem()
    {
        itemIndex = Random.Range(1, 3);
        player2HUD.ShowItem(itemIndex);
    }
}