using System.Collections;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public CollisionDetecter detecter;
    public SpeedController speedController;
    public SceneManagement manager;

    public Animator animator;
    private Rigidbody2D playerRb;

    private Vector3 playerPos;

    [SerializeField] float movingSpeed = 1500f;
    [SerializeField] public float coolDown;
    [SerializeField] private float threshold = 0.1f;

    private bool isFacingRight = true;
    public bool isMovingUp;
    public bool flipping = false;
    private bool canMove => !manager.isGameOver;

    private void Awake()
    {
        detecter = GetComponent<CollisionDetecter>();
        speedController = GetComponent<SpeedController>();
        manager=FindObjectOfType<SceneManagement>();
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
    }

    private void FixedUpdate()
    {
            if (detecter.isGrounded && Input.GetKey(KeyCode.Space))
            {
                if (coolDown > 0.035f)
                {
                    StartCoroutine(Jump());
                }
            }
            StartCoroutine(Move());
            StartCoroutine(AssignRotation());
        if(manager.isGameOver)
        {
            StopAllCoroutines();
        }
    }

    public IEnumerator Jump()
    {
        float jumpAmount = speedController.jumpForce * Time.deltaTime;
        playerRb.velocity = new Vector2(playerRb.velocity.x, speedController.jumpForce);
        yield return null;
    }

    public IEnumerator Move()
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
        yield return null;

    }

    public IEnumerator AssignRotation()
    {
        if (Input.GetAxis("Horizontal") > 0 && !isFacingRight)
            ChangeDirection();
        else if (Input.GetAxis("Horizontal") < 0 && isFacingRight)
            ChangeDirection();
        yield return null;
    }
    private void ChangeDirection()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }


    public Vector3 GetPlayerPos()
    {
        playerPos = transform.GetChild(0).position;
        return playerPos;
    }

}
