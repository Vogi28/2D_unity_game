using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;
    private bool isGrounded = false;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mv = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += mv * Time.deltaTime * speed;
        //horizontalMove = Input.GetAxis("Horizontal") * mvSpeed;

        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("isMoving", true);
        }

        if (Input.GetKeyDown("space") && isGrounded)
        {
            jump();
        }
    }

    void jump()
    {
        //Vector3 jp = new Vector3(0f, speed, 0f);
        //transform.position += jp * Time.deltaTime * speed;
        rb.velocity += new Vector2(0, speed);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

}
