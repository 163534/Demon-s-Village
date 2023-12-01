using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public GameObject projSpawn;
    public GameObject spear;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    public float speed;
    public float jumpForce;
    float horizontalMove;
    public int dir;
    string currentStates;
    bool moveRight;
    bool moveLeft;
    bool crouch;
    bool climb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        dir = 1;
    }
    private void Update()
    {
        Movement();
        Animations();
    }
    
    public void PointerDownRight()
    {
        moveRight = true;
    }
    public void PointerUpRight()
    {
        moveRight = false;
    }
    public void PointerDownLeft()
    {
        moveLeft = true;
    }
    public void PointerUpLeft()
    {
        moveLeft = false;
    }
    // Update is called once per frame
    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    public void Shoot()
    {
        Instantiate(spear, projSpawn.transform.position, Quaternion.identity);
    }
    public void Movement()
    {
        if (moveRight)
        {
            dir = 1;
            rb.velocity = new Vector2(1 * speed, rb.velocity.y);
            if (dir == 1)
            {
                sr.flipX = false;
            }
        }
        else if (moveLeft)
        {
            dir = -1;
            rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
            if (dir == -1)
            {
                sr.flipX = true;
            }
        }
    }
    void Animations()
    {
        
        if(rb.velocity.x != 0)
        {
            ChangeAnim("PlayerRunAnimation");
        }
        else if(rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            ChangeAnim("PlayerIdleAnimation");
        }
    }
    public void ChangeAnim(string newState)
    {
        if (currentStates == newState) return;

        anim.Play(newState);

        currentStates = newState;
    }

}
