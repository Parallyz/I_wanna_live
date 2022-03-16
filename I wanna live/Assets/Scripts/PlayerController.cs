using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

    public float min_speed;
    public float max_speed;
    private bool isGrounded;

    private Animator animator;
    public int jumpPower;

    public float checkRadius;

    private Vector2 respawnPos;
    public Transform groundCheck;

    public LayerMask theGround;

    private Rigidbody2D rb;
    private bool isAlive =true;

    [SerializeField]
    private GameObject fallDetect;
    private new CapsuleCollider2D collider2D;

    private SpriteRenderer sprite;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider2D = GetComponent<CapsuleCollider2D>();
        sprite= GetComponent<SpriteRenderer>();


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
        if (speed < max_speed)
        {
            speed += 0.05f;
        }

    }



    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && isAlive)
        {
            // print("ad");
            animator.SetBool("isJump", true);
            Jump();
        }
        fallDetect.transform.position = new Vector2(transform.position.x, fallDetect.transform.position.y);

    }

    private void Init()
    {

        GameController.instanse.SetHunterRespownPosition();


    }

    void Jump()
    {
        GameController.instanse.SetPlayerJumpPosition();
        rb.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);

        speed = min_speed;
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
            isAlive=false;
            animator.SetBool("isDying", true);
            speed = 0;
            Invoke("killHero", 2);

        }
    }

   

    private void gameOver()
    {
        LevelController.instanse.LevelFall();
    }
    private void killHero()
    {
       
        
        LevelController.instanse.LevelFallWithoutPause();
    }

}
