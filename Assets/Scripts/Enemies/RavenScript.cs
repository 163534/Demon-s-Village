using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RavenScript : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    LayerMask playerMask;
    
    public float detectDis;
    float timerLimit;
    float timer;
    float move;
    string currentStates;

    [SerializeField]
    float speed;
    [SerializeField]
    float frequency;
    [SerializeField]
    float magnitude;
    [SerializeField]
    float offset;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMask = LayerMask.GetMask("Player");
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        
        timer = 0;
        timerLimit = 8;
        
        move = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (move == 0)
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
            move = 1;
            Debug.Log("Player Detected");
        }
        Debug.DrawRay(transform.position, Vector2.right * detectDis, Color.red);
        if (Physics2D.Raycast(transform.position, Vector2.right, detectDis, playerMask))
        {
            move = 2;
            Debug.Log("Player Detected");
        }
    }
    void Movement()
    {
        if (move == 1)
        {
            sr.flipX = false;
            transform.Translate(new Vector2(-1f, 0f) * speed * Time.deltaTime);
            transform.position = transform.position + transform.up * SineAmount();
        }
        else if(move == 2)
        {
            sr.flipX = true;
            transform.Translate(new Vector2(1f, 0f) * speed * Time.deltaTime);
            transform.position = transform.position + transform.up * SineAmount();
        }
    }
    public float SineAmount()
    {
        return Mathf.Sin(Time.time * frequency + offset) * magnitude;
    }
    public void ChangeAnim(string newState)
    {
        if (currentStates == newState) return;

        anim.Play(newState);

        currentStates = newState;
    }
    public void Death()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 8)
        {
            Debug.Log("Hit. Raven.");
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            ChangeAnim("RavenDeathAnimation");
            //Destroy
        }
    }
}
