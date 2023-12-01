using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerProjectile : MonoBehaviour
{
    PlayerController pc;
    Rigidbody2D rb;
    SpriteRenderer sr;
    bool movingRight;
    bool movingLeft;
    float timer;
    float timerDelay;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        timer = 0;
        timerDelay = 5;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(pc.dir == 1 && !movingLeft)
        {
            sr.flipX = false;
            rb.velocity = new Vector2(1 * 10, rb.velocity.y);
            movingRight = true;
            movingLeft = false;
        }
        else if(pc.dir == -1 && !movingRight)
        {
            sr.flipX = true;
            rb.velocity = new Vector2(-1 * 10, rb.velocity.y);
            movingRight = false;
            movingLeft = true;
        }
        if(timer >= timerDelay)
        {
            Destroy(gameObject);
        }
    }
}
