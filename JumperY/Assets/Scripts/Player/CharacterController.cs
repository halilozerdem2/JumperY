using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class CharacterController : MonoBehaviour
{
    public CollisionDetecter detecter;
    public SpeedController speedController;
    public Animator animator;
    private Rigidbody2D playerRb;

    [SerializeField] float movingSpeed = 1500f;
    [SerializeField] public float coolDown;
    [SerializeField] private float threshold = 0.1f;

    private Vector3 playerPos;

    private float jumpForce;
    private bool isFacingRight = true;
    public bool isMovingUp;
    public bool flipping = false;


    private void Awake()
    {
        detecter = GetComponent<CollisionDetecter>();
        speedController = GetComponent<SpeedController>();
        animator = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (playerRb.velocity.y > threshold)
        {
            isMovingUp = true;
        }
        else
        {
            isMovingUp = false;

        }
        animator.SetBool("isJumping", isMovingUp);

        coolDown += Time.deltaTime;
        SetJumpPower();

    }

    private void FixedUpdate()
    {
        if (detecter.isGrounded && Input.GetKey(KeyCode.Space))
        {
            if (coolDown > 0.035f)
            {
                Jump();
            }
        }
        Move();

        AssignRotation();

    }

    private void Jump()
    {
        float jumpAmount = jumpForce * Time.deltaTime;
        playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
    }
    private void Move()
    {
        float moveAmount = Input.GetAxis("Horizontal") * movingSpeed * Time.deltaTime; ;
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        if (!detecter.isGrounded)
        {
           Vector3 targetPoisition= new Vector3(transform.position.x + Input.GetAxis("Horizontal") * 7f *
                                Time.deltaTime, transform.position.y, transform.position.z);
           transform.position= Vector3.MoveTowards(transform.position, targetPoisition, 8f* Time.deltaTime);
        }
            

        if (Mathf.Abs(playerRb.velocity.x) <= 15)
        {
            playerRb.AddForce(new Vector2(moveAmount, playerRb.velocity.y + 5f));
        }
    }

    private void AssignRotation()
    {
        if (Input.GetAxis("Horizontal") > 0 && !isFacingRight)
            ChangeDirection();
        else if (Input.GetAxis("Horizontal") < 0 && isFacingRight)
            ChangeDirection();
    }
    private void ChangeDirection()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }

    private float SetJumpPower()
    {
        if (Mathf.Abs(playerRb.velocity.x) == 0)
            jumpForce = 15f;

        else if ((Mathf.Abs(playerRb.velocity.x) > 0f && (Mathf.Abs(playerRb.velocity.x) < 5f)))
            jumpForce = 16f;
        else if ((Mathf.Abs(playerRb.velocity.x) >= 5f && (Mathf.Abs(playerRb.velocity.x) < 10f)))
            jumpForce = 20f;
        else if ((Mathf.Abs(playerRb.velocity.x) >= 10f && (Mathf.Abs(playerRb.velocity.x) < 15f)))
            jumpForce = 25;
        else if ((Mathf.Abs(playerRb.velocity.x) >= 15f && (Mathf.Abs(playerRb.velocity.x) < 20f)))
        {
            jumpForce = 28f;
        }
        else
        {
            jumpForce = 30f;
        }

        return jumpForce;
    }

    private void Flip()
    {
        flipping = true;
        transform.Rotate(0, 0, -15f);
        flipping = false;
    }

    public Vector3 GetPlayerPos()
    {
        playerPos = transform.GetChild(0).position;
        return playerPos;
    }

}
