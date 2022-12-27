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
    private Rigidbody2D playerRb;

    private Collider2D playerCollider;
    private PlatformTrigger platformCollider;

    [SerializeField] float movingSpeed= 1500f;
    public float coolDown;
    private float jumpForce;
    private bool isFacingRight = true;
    private Vector3 playerPos;


    private void Awake()
    {
        detecter= GetComponent<CollisionDetecter>();
        speedController= GetComponent<SpeedController>();
        playerRb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        coolDown += Time.deltaTime;
        SetJumpPower();
        
    }

    private void FixedUpdate()
    {
       
        if (detecter.isGrounded && Input.GetKey(KeyCode.Space))
        {
            if(coolDown> 0.035f)
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
        playerRb.velocity=new Vector2 (playerRb.velocity.x, jumpForce);
    }
    private void Move()
    {
        float moveAmount = Input.GetAxis("Horizontal") * movingSpeed * Time.deltaTime;;
        if (!detecter.isGrounded)
            moveAmount *= 2;
      
        if (Mathf.Abs(playerRb.velocity.x) <= 15)
        {
            playerRb.AddForce(new Vector2(moveAmount, playerRb.velocity.y+5f));
        }
        
    }

    private void AssignRotation()
    {
        if (playerRb.velocity.x > 0 && !isFacingRight)
            ChangeDirection();
        else if(playerRb.velocity.x < 0 && isFacingRight)
            ChangeDirection();
    }
   private void ChangeDirection()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(-transform.localScale.x,transform.localScale.y);
    }

    private float SetJumpPower()
    {   
        if(Mathf.Abs(playerRb.velocity.x) == 0) 
            jumpForce= 15f;

        else if((Mathf.Abs(playerRb.velocity.x) > 0 && (Mathf.Abs(playerRb.velocity.x) < 5)))
            jumpForce = 20f;
        else if((Mathf.Abs(playerRb.velocity.x) > 5 && (Mathf.Abs(playerRb.velocity.x) < 10)))
            jumpForce = 25;
        else
            jumpForce = 30;

        return jumpForce;
    }
    public Vector3 GetPlayerPos() 
    { 
        playerPos=transform.GetChild(0).position;
        return playerPos; 
    }

}
