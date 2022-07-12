using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchPlayer : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    public float Force = 200;

    private Rigidbody2D rb;
    public Animator anim;

    private bool facingRight = true;
    private bool knockRight;
    private bool knockLeft;

    [SerializeField] bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;




    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }



    private void FixedUpdate()
    {
       // isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        //anim.SetFloat("Speed", Mathf.Abs(moveInput));

        if(moveInput == 0)
        {
            anim.SetBool("IsRunning", false);
        }
        else
        {
            anim.SetBool("IsRunning", true);
        }

        if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
        else if (facingRight == false && moveInput > 0)
        {
            Flip();
        }

        if (knockLeft == true)
        {
            rb.AddForce(transform.right * Force, ForceMode2D.Impulse);
            rb.AddForce(transform.up * Force, ForceMode2D.Impulse);
            Debug.Log("noc");
        }

        if (knockRight == true)
        {
            rb.AddForce(-transform.right * Force, ForceMode2D.Impulse);
            rb.AddForce(transform.up * Force, ForceMode2D.Impulse);
            Debug.Log("noc1");
        }


    }

    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
       {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("TakeOf");
        }
        if (isGrounded == false)
        {
            anim.SetBool("IsJumping", true);
        }
        else
        {
            anim.SetBool("IsJumping", false);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 Scaler = transform.localScale;

        Scaler.x *= -1;
        transform.localScale = Scaler;

        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "BOX")
        {
            isGrounded = true;
        }

        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        if (col.gameObject.tag == "Enemy" && facingRight == false)
        {
            knockLeft = true;
            Debug.Log("Fly1");
        }

        if (col.gameObject.tag == "Enemy" && facingRight == true)
        {
            knockRight = true;
            Debug.Log("Fly2");
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "BOX")
        {
            isGrounded = false;
        }

        if (col.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }

        if (col.gameObject.tag == "Enemy")
        {
            knockLeft = false;
        }

        if (col.gameObject.tag == "Enemy")
        {
            knockRight = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        if (collision.gameObject.tag == "BOX")
        {
            isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
        if (collision.gameObject.tag == "BOX")
        {
            isGrounded = false;
        }
    }
}
