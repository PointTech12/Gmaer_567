using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;


    public Transform firePoint;
    public GameObject bulletPrefab;

    private float horizontalMove;
    private bool moveRight;
    private bool moveLeft;
    private bool moveUp;
    private bool shoot;
    private Rigidbody2D rb;
    private float horizontalInput;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private bool grounded;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        moveLeft = false;
        moveRight = false;
        moveUp = false;
        shoot = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        Movement();
    }
    public void pointerDownLeft()
    { 
        moveLeft=true;
        
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        anim.SetBool("run", horizontalInput != 0);
    }
    public void pointerUpLeft() 
    { 
        moveLeft =false;
    }
    public void pointerDownRight()
    { 
        moveRight=true;
        
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        anim.SetBool("run", horizontalInput != 0);
    }
    public void pointerUpRight() 
    {
        moveRight = false;
    }
    public void pointerUpJump()
    {
            moveUp =false;
    }
    public void pointerDownJump() 
    {
        moveUp=true;
        if (grounded) 
        {
            Jump();
        }

    }
    public void pointerUpShoot()
    {
        shoot = false;
    }
    public void pointerDownShoot()
    {
        shoot = true;
        PlayAttackAnimation();
        Shoot();
    }
    void Movement()
    {
        if (moveLeft)
        {
            horizontalMove = -speed;
        }
        else if (moveRight)
        {
            horizontalMove = speed;
        }
        else 
        {
            horizontalMove = 0;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    void PlayAttackAnimation()
    {
        // Ensure the animator is not null
        if (anim != null)
        {
            // Trigger the attack animation parameter (assuming you have a trigger parameter named "Attack")
            anim.SetTrigger("attack");
        }
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, speed);
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
}
