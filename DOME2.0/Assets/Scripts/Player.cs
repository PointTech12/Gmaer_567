using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    public float speed;
    private float horizontalMove;
    private bool moveRight;
    private bool moveLeft;
    private Rigidbody2D rb;
    private float horizontalInput;
    private Animator anim;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveLeft = false;
        moveRight = false;
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
        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        anim.SetTrigger("run");
    }
    public void pointerUpLeft() 
    { 
        moveLeft =false;
    }
    public void pointerDownRight()
    { 
        moveRight=true;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        anim.SetBool("run", true);
    }
    public void pointerUpRight() 
    {
        moveRight = false;
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
}
