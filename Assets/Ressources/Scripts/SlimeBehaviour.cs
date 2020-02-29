using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehaviour : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // move slime
        Vector3 mv = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += mv * Time.deltaTime * speed;

        Debug.Log(transform.position);

        // check moving input
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        // check jump key and grounded condition
        if (Input.GetKeyDown("space"))
        {
            animator.SetBool("IsJumping", true);
            if (isGrounded)
            {
                jump();
            }
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }

    }

    // function character jump
    private void jump()
    {
        rb.velocity += new Vector2(0, speed);
    }

    // function to check collision in
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // function to check collision out
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
