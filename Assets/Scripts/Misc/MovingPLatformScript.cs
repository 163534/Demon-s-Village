using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovingPLatformScript : MonoBehaviour
{
    int dir;
    [SerializeField]
    float rayLength;
    [SerializeField]
    float speed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dir = 1;
    }

    // Update is called once per frame
    void Update()
    {
        DirectionCheck();
        Move();
    }
    void Move()
    {
        if(dir == 1)
        {
            rb.velocity = new Vector2(dir * speed, rb.velocity.y);
        }
        else if(dir == -1)
        {
            rb.velocity = new Vector2(dir * speed, rb.velocity.y);
        }
    }
    void DirectionCheck()
    {
        if (Physics2D.Raycast(gameObject.transform.position, Vector2.left, rayLength))
        {
            dir = 1;
        }
        if (Physics2D.Raycast(gameObject.transform.position, Vector2.right, rayLength))
        {
            dir = -1;
        }
    }
}
