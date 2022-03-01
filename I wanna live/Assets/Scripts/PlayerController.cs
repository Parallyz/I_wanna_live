using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed;
    private bool isGrounded;

    private Animator animator;
    private int jumpPower;

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

        GameManager.instanse.player_respown = this.transform.position;
        speed = GameManager.instanse.player_current_speed;
        GameManager.instanse.player_width = collider2D.size.x;
        jumpPower = GameManager.instanse.jumpPower;

    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, theGround);
        animator.SetBool("isJump", !isGrounded);
        rb.velocity = new Vector2(speed, rb.velocity.y);
        if (speed < GameManager.instanse.player_max_speed)
        {
            speed += 0.05f;
        }
        GameManager.instanse.player_current_speed = speed;
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            animator.SetBool("isJump", true);
            Jump();
        }
        fallDetect.transform.position = new Vector2(transform.position.x, fallDetect.transform.position.y);
    }

    void Jump()
    {
        rb.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
        speed = GameManager.instanse.player_min_speed;
        GameManager.instanse.player_jump_position = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FallDetector"))
        {
            gameOver();
        }
        if (other.CompareTag("Hunter"))
        {
            animator.SetBool("isDying", true);
        }
    }

    private void gameOver()
    {
        LevelController.instanse.LevelSuccess();
    }
}
