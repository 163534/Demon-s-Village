using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RavenScript : MonoBehaviour
{
    Rigidbody2D rb;
    LayerMask playerMask;
    Animator anim;
    public float detectDis;
    float timerLimit;
    float timer;
    bool move;
    string currentStates;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMask = LayerMask.GetMask("Player");
        anim = GetComponent<Animator>();
        timer = 0;
        timerLimit = 8;
        
        move = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!move)
        {
            CheckForPlayer();
            
        }
        else
        {
            timer += Time.deltaTime;
            Movement();
            ChangeAnim("RavenFlyAnimation");

            if (timer >= timerLimit)
            {
                Destroy(gameObject);
            }
        }
        
        
    }
    void CheckForPlayer()
    {
        Debug.DrawRay(transform.position, Vector2.left * detectDis, Color.red);
        if (Physics2D.Raycast(transform.position, Vector2.left, detectDis, playerMask))
        {
            move = true;
            Debug.Log("Player Detected");
        }
    }
    void Movement()
    {
        if (move)
        {
            rb.velocity = new Vector2(-0.5f, rb.velocity.y);
            rb.velocity = new Vector2(rb.velocity.x, SineAmount());
        }
    }
    public float SineAmount()
    {
        return Mathf.Sin(Time.time * 9f);
    }
    public void ChangeAnim(string newState)
    {
        if (currentStates == newState) return;

        anim.Play(newState);

        currentStates = newState;
    }

}
