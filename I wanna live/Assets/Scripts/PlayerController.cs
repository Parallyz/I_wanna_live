using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 0;
    private bool isGrounded;

    private Animator animator;
    private int jumpPower = 0;

    public float checkRadius;

    private Vector2 respawnPos;
    public Transform groundCheck;

    public LayerMask theGround;

    private Rigidbody2D rb;


    [SerializeField]
    private GameObject fallDetect;
    private new CapsuleCollider2D collider2D;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider2D = GetComponent<CapsuleCollider2D>();



    }

    private void FixedUpdate()
    {
        Init();
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, theGround);
        animator.SetBool("isJump", !isGrounded);

        GameController.instanse.SetPlayerIsJump(!isGrounded);
        if (GameController.instanse.isRun)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);

        }
        if (speed < GameController.instanse.player_max_speed)
        {
            speed += 0.05f;
        }
        GameController.instanse.SetPlayerCurrentSpeed(speed);
    }



    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // print("ad");
            animator.SetBool("isJump", true);
            Jump();
        }
        fallDetect.transform.position = new Vector2(transform.position.x, fallDetect.transform.position.y);

    }

    private void Init()
    {
        if (speed == 0 || jumpPower == 0)
        {
            GameController.instanse.SetHunterRespownPosition();
            speed = GameController.instanse.player_current_speed;
            jumpPower = GameController.instanse.jumpPower;
        }
    }

    void Jump()
    {
        GameController.instanse.SetPlayerJumpPosition();
        rb.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);

        //  speed = GameController.instanse.player_min_speed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("FallDetector"))
        {
            gameOver();
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("FallDetector"))
        {
            gameOver();
        }
        if (other.gameObject.CompareTag("Hunter"))
        {
            animator.SetBool("isDying", true);
            speed = 0;

        }
    }



    private void gameOver()
    {
        LevelController.instanse.LevelFall();
    }
}
