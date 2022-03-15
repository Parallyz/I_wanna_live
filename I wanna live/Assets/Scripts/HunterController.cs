using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterController : MonoBehaviour
{
    // Start is called before the first frame update

    private float speed = 0;
    private Animator animator;
    private bool isGrounded;
    private int jumpPower = 0;
    public Transform groundCheck;
    private Rigidbody2D rb;

    private new CapsuleCollider2D collider2D;
    public float checkRadius;
    public LayerMask theGround;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider2D = GetComponent<CapsuleCollider2D>();


    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, theGround);
        if (GameController.instanse.isRun)
            rb.velocity = new Vector2(speed, rb.velocity.y);

       
    }




    void Update()
    {
        Init();
         if (GameController.instanse.isTimeToJump() && isGrounded)
        {
            Jump();
        }
    }

    private void Init()
    {
        if (speed == 0 || jumpPower == 0)
        {
            speed = GameController.instanse.hunter_current_speed;
            jumpPower = GameController.instanse.jumpPower;

            GameController.instanse.SetHunterRespownPosition();
        }
    }
   
    void Jump()
    {
        rb.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
        GameController.instanse.isPlayerJump = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            GameController.instanse.StopMoving();


            animator.SetBool("isSlash", true);

            animator.SetBool("isIdle", true);

        }
    }


}
