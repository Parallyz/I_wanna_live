using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterController : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;

    private Animator animator;
    private bool isGrounded;
    public int jumpPower;
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
        animator.SetFloat("speed", speed);
       
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, theGround);
        if (GameController.instanse.isRun)
            rb.velocity = new Vector2(speed, rb.velocity.y);

        animator.SetBool("isJump", !isGrounded);

    }




    void Update()
    {

        if (isTimeToJump() && isGrounded)
        {
            animator.SetBool("isJump", true);
            Jump();
        }
    }
    public bool isTimeToJump()
    {
        if (GameController.instanse.player_jump_position != null)
        {
            return GameController.instanse.isPlayerJump &&
                   GameController.instanse.player_jump_position.x >=
                   GameController.instanse.hunter.transform.position.x - 0.5 &&
                   GameController.instanse.player_jump_position.x <=
                   GameController.instanse.hunter.transform.position.x + 0.5;
            ;
        }
        return false;
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
            speed = 0;


        }
    }


}
