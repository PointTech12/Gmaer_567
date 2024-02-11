using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = PointB.transform;
        anim.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == PointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else { 
             rb.velocity = new Vector2 (-speed, 0);
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.05f && currentPoint == PointB.transform) {
            flisp();
            currentPoint = PointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.05f && currentPoint == PointB.transform)
        {
            flisp();
            currentPoint = PointB.transform;
        }
    }
    private void flisp() { 
        Vector3 localScale = transform.localScale;
        localScale.x += -1;
        transform.localScale = localScale;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PointA.transform.position, 0.05f);
        Gizmos.DrawWireSphere(PointB.transform.position, 0.05f);
        Gizmos.DrawLine(PointA.transform.position, PointB.transform.position);
    }
}
