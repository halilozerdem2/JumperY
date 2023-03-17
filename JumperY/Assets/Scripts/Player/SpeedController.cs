using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    Rigidbody2D playerRb;
    public float jumpForce;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        SetJumpPower();
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
}
