using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerProjectile : MonoBehaviour
{
    PlayerStateMachine pc;
    Rigidbody2D rb;
    SpriteRenderer sr;
    bool movingRight;
    bool movingLeft;
    float timer;
    float timerDelay;
    [SerializeField]
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStateMachine>();
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
            rb.velocity = new Vector2(1 * speed, rb.velocity.y);
            movingRight = true;
            movingLeft = false;
        }
        else if(pc.dir == -1 && !movingRight)
        {
            sr.flipX = true;
            rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
            movingRight = false;
            movingLeft = true;
        }
        if(timer >= timerDelay)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == 3)
        {
            Destroy(gameObject);    
        }
    }
}
