using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LadderClimbingScript : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float distance;
    [SerializeField] float distance2;

    public bool isClimbing;
    bool upButton;
    bool downButton;
    bool climbingUp;
    bool climbingDown;
    [SerializeField]
    Rigidbody2D rb;
    public LayerMask ladder;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        RayCheck();
        //Debug.Log(upButton);
        //Debug.Log(downButton);

    }
     public void UpButtonUp()
    {
        upButton = false;
    }
    public void UpButtonDown()
    {
        upButton = true;
    }
    public void DownButtonUp()
    {
        downButton = false;
    }
    public void DownButtonDown()
    {
        downButton = true;
    }

    void CheckInput()
    {
        if (upButton)
        {
            climbingUp = true;
        }
        else if(!upButton)
        {
            climbingUp = false;
        }
        if (downButton)
        {
            climbingDown = true;
        }
        else if(!downButton)
        {
            climbingDown = false;
        }
        else if (!downButton && !upButton)
        {
            return;
        }
    }
    void RayCheck()
    {
        Color cl = Color.red;
        Color cl2 = Color.green;
        Debug.Log(isClimbing);

        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.up, distance, ladder);
        RaycastHit2D hitinfo2 = Physics2D.Raycast(transform.position, -Vector2.up, distance2, 0);
        int climbingDir = 0;
        Debug.Log(hitinfo);
        if (hitinfo.collider != null)
        {
            Debug.DrawRay(transform.position, Vector2.up * distance, cl);
            if (climbingUp)
            {
                isClimbing = true;
                climbingDir = 1;
            }
            else if (climbingDown)
            {
                isClimbing = true;
                climbingDir = -1;
            }
            else
            {
                climbingDir = 0;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, Vector2.up * distance, cl2);
            isClimbing = false;
        }
        if (isClimbing)
        {
            Debug.Log(climbingDir);
            rb.gravityScale = 0;
            gameObject.layer = LayerMask.NameToLayer("ClimbingLayer");
            //rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.velocity = new Vector2(rb.velocity.x, climbingDir * speed);

        }
        else
        {
            rb.gravityScale = 1;
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
    }
}
