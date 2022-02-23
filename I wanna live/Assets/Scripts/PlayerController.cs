using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 7;
    private bool isGrounded;

   
    private int jumpPower = 20;

    public float checkRadius;
    public Transform groundCheck;

    public LayerMask theGround;

    private Rigidbody2D rb;

 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, theGround);
      //  var Posx = rb.velocity.x + speed;
       // print(Time.fixedDeltaTime);
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
    }
}
