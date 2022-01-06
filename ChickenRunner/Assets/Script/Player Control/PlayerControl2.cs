using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl2 : MonoBehaviour
{
    const float forwardSpeedLimit = 100f, SpeedUpEffectTimeLimit = 5.0f;

    public Rigidbody rb;
    public float forwardSpeed, reverseSpeed, turnSpeed;
    public bool isGrounded;
    public LayerMask ground;
    public PlayerHUD player2HUD;

    private float moveInput, turnInput, SpeedUpEffectTime = SpeedUpEffectTimeLimit;
    private int itemIndex = 0;
    private bool isSpeedUp = false;
    private bool Run = false;
    private Animator animator;
    private DropBarrier dropBarrier;

    void Start()
    {
        rb.transform.parent = null;
        animator = GetComponent<Animator>();
        dropBarrier = GetComponentInChildren<DropBarrier>();
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
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) Run = true;
        animator.SetBool("Run", Run);
        //press space to use item if item is availible
        if (Input.GetKey(KeyCode.Slash) && itemIndex > 0)
        {
            UseItem();
        }

        //check item effect timer
        if (isSpeedUp)
        {
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
    public void GetItem()
    {
        itemIndex = Random.Range(1, 3);
        player2HUD.ShowItem(itemIndex);
    }

    private void UseItem()
    {
        if (itemIndex == 1)
        { // speed up 1.5x
            forwardSpeed *= 2.0f;
            isSpeedUp = true;
        }
        else if (itemIndex == 2)
        {
            dropBarrier.Drop();
        }
        itemIndex = 0;
        player2HUD.ShowItem(itemIndex);
    }

    private void SpeedUpTimer()
    {
        SpeedUpEffectTime -= Time.deltaTime;
        if (SpeedUpEffectTime <= 0)
        {
            forwardSpeed = forwardSpeedLimit;
            isSpeedUp = false;
            SpeedUpEffectTime = SpeedUpEffectTimeLimit;
        }
    }
}