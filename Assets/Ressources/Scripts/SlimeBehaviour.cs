using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehaviour : MonoBehaviour
{
    public float speed = 5f;
    public float dashSpeed;
    public float startDashTime;
    public float distanceBetweenImages;
    private float dashTime;
    private float lastSprint;
    private float lastImageXpos;
    
    private const float DOUBLE_PRESS = .2f;
    
    private bool isDashing = false;
    private bool isGrounded = false;
    
    private Vector3 moving;
    
    private Animator animator;
    private Rigidbody2D rb;
    public HealthBar HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        dashTime = startDashTime;
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
        sprint(axisX);
        dash(axisX);
        
    }
    // move the character
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
            _scale.x = -Mathf.Abs(_scale.x);
        else
            _scale.x = Mathf.Abs(_scale.x);

        transform.localScale = _scale;
    }

    // character jump
    private void jump()
    {
        rb.velocity += new Vector2(0, (speed * 1.4f));
    }

    // double press sprint
    private void sprint(float axisX)
    {
        if (Input.GetKeyDown("right") || Input.GetKeyDown("left"))
        {
            // time compare
            float timeSinceLastSprint = Time.time - lastSprint;

            if (timeSinceLastSprint <= DOUBLE_PRESS)
                rb.velocity = new Vector2(axisX * speed / 2, 0);
            else
                rb.velocity = Vector2.zero;
            
            // last press
            lastSprint = Time.time;
            
            //Debug.Log("Last sprint : " + lastSprint);
        }
    }

    // double press dash
    private void dash(float axisX)
    {
        if (!isDashing)
        {
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                isDashing = true;
                // get ga.o from pool
                AfterImagePool.Instance.GetFromPool();
                // save the position of this ga.o
                lastImageXpos = transform.position.x;

                FindObjectOfType<Health_Damage>().ManaUse(1);
            }
        }
        else
        {        
            if (dashTime <= 0)
            {
                isDashing = false;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;
                rb.velocity = new Vector2(axisX, 0) * dashSpeed;

                // check distance between images
                if (Mathf.Abs(transform.position.x - lastImageXpos) > distanceBetweenImages)
                {
                    AfterImagePool.Instance.GetFromPool();
                    lastImageXpos = transform.position.x;
                }
            }
        }
    }

    // check collision in
    private void OnCollisionEnter2D(Collision2D col)
    {
        // compare object by tag
        if(col.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    // check collision out
    private void OnCollisionExit2D(Collision2D col)
    {
        // compare object by tag
        if (col.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Life"))
        {
            float health = HealthBar.slider.value + 1f;
            HealthBar.setHealth((int)health);
            
            Destroy(col.gameObject);
        }
    }
}
