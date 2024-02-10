using UnityEngine;
using UnityEngine.UI;

public class ADKeys : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private float speed;

    private bool moveRight;
    private bool moveLeft;
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveLeft = false;
        moveRight = false;
    }

    void Update()
    {
        Movement();
    }

    public void PointerDownLeft()
    {
        moveLeft = true;
        moveRight = false;
    }

    public void PointerUpLeft()
    {
        moveLeft = false;
    }

    public void PointerDownRight()
    {
        moveRight = true;
        moveLeft = false;
    }

    public void PointerUpRight()
    {
        moveRight = false;
    }

    void Movement()
    {
        if (moveLeft)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            anim.SetTrigger("run");
        }
        else if (moveRight)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            anim.SetTrigger("run");
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            anim.SetTrigger("idle");
        }
    }
}
