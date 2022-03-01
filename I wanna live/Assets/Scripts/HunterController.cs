using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterController : MonoBehaviour
{
    // Start is called before the first frame update

    private float speed;
    private Animator animator;

    private int jumpPower;

    private Rigidbody2D rb;

    private new CapsuleCollider2D collider2D;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider2D = GetComponent<CapsuleCollider2D>();

        GameManager.instanse.hunter_respown = this.transform.position;
        speed = GameManager.instanse.hunter_current_speed;
        GameManager.instanse.hunter_width = collider2D.size.x;

        jumpPower = GameManager.instanse.jumpPower;
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        CheckTouch();
        if (isTimeToJump())
        {
            Jump();
        }
    }

    private bool isTimeToJump()
    {
        if (GameManager.instanse.player_jump_position != null)
        {
            return GameManager.instanse.isPlayerJump &&
                    GameManager.instanse.player_jump_position.x ==
                    GameManager.instanse.hunter.transform.position.x;
        }
        return false;
    }

    private void CheckTouch()
    {
        var isTouch = this.transform.position.x - GameManager.instanse.hunter_width;

    }
    void Update()
    {

    }

    void Jump()
    {
        rb.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("isSlash", true);
            speed = 0;
            animator.SetBool("isIdle", true);

        }
    }
}
