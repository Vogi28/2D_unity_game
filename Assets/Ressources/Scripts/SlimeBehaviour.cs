using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehaviour : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    private Animator animator;
    private Vector3 moving;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void FixedUpdate()
    {
        float axisX = Input.GetAxis("Horizontal");

        move(axisX);
        flip(axisX);
        //Debug.Log(moving);
    }

    private void move(float axisX)
    {

        // move slime
        moving = new Vector3(axisX, 0f, 0f);
        transform.position += moving * Time.deltaTime * speed;

        // check moving input
        if (axisX != 0)
            animator.SetBool("IsMoving", true);
        else
            animator.SetBool("IsMoving", false);

        // check jump key and grounded condition
        if (Input.GetButtonDown("Jump") && isGrounded)
            jump();

        // animation condition check
        if (isGrounded)
            animator.SetBool("IsJumping", false);
        else
            animator.SetBool("IsJumping", true);
    }

    // flip the character
    private void flip(float axisX)
    {
            Vector3 _scale = transform.localScale;
        if (axisX < 0)
            _scale.x *= -1;
        else
            _scale.x *= 1;

        transform.localScale = _scale;
    }

    // function character jump
    private void jump()
    {
        rb.velocity += new Vector2(0, (speed * 1.4f));
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
