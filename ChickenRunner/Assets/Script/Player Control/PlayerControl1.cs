using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl1 : MonoBehaviour
{
    const float forwardSpeedLimit = 100f, SpeedUpEffectTimeLimit = 5.0f;

    public Rigidbody rb;
    public float forwardSpeed = forwardSpeedLimit, reverseSpeed, turnSpeed;
    public bool isGrounded;
    public LayerMask ground;
    public PlayerHUD player1HUD;

    private float moveInput, turnInput, SpeedUpEffectTime = SpeedUpEffectTimeLimit;
    private int itemIndex = 0;
    private bool isSpeedUp = false;
    private bool Run = false;
    private Animator animator;

    void Start()
    {
        rb.transform.parent = null;
        animator = GetComponent<Animator>();
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

        //check press key for run animations
        Run = false;
        if (Input.GetKey(KeyCode.W)) Run = true;
        animator.SetBool("Run", Run);
        //press space to use item if item is availible
        if (Input.GetKey(KeyCode.Space) && itemIndex > 0) {
            UseItem();
        }

        //check item effect timer
        if (isSpeedUp) {
            SpeedUpTimer();
        }
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

    public void GetItem() {
        itemIndex = Random.Range(1, 3);
        player1HUD.ShowItem(itemIndex);
    }

    private void UseItem() {
        if (itemIndex == 1) { // speed up 1.5x
            forwardSpeed *= 2.0f;
            isSpeedUp = true;
        }
        itemIndex = 0;
        player1HUD.ShowItem(itemIndex);
    }

    private void SpeedUpTimer() {
        SpeedUpEffectTime -= Time.deltaTime;
        if (SpeedUpEffectTime <= 0) {
            forwardSpeed = forwardSpeedLimit;
            isSpeedUp = false;
            SpeedUpEffectTime = SpeedUpEffectTimeLimit;
        }
    }
}
