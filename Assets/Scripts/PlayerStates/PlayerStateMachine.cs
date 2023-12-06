using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public interface PState
{
    public void UpdateState();
    public void FixedUpdateState();
    public void OnEnterState(PlayerStateMachine psm);
    public void OnExitState();
}
public class PlayerStateMachine : MonoBehaviour
{
    public PState currentState, lastState;
    public RightButtonState rightButtonState = new();
    public LeftButtonState leftButtonState = new();
    public PlayerIdleState playerIdleState = new();
    public FireButtonState fireButtonState = new();
    LadderClimbingScript lcs;

    Animator anim;
    public Rigidbody2D rb;
    public GameObject projSpawn;
    public GameObject spear;
    public SpriteRenderer sr;
    private string currentStates;
    public bool moveLeft;
    public bool moveRight;
    public bool shooting;
    public bool jumping;
    public bool dead;
    public float speed;
    public float jumpForce;
    public int dir;
    public int health;

    private void Start()
    {
        dead = false;
        health = 1;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        lcs = GetComponent<LadderClimbingScript>();
        dir = 1;
        ChangeState(playerIdleState);
    }
    void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState();
        }
        CheckInput();
        HealthCheck();
        //Debug.Log(currentState);
        //Debug.Log(shooting);
    }
    private void FixedUpdate()
    {
        if (currentState != null)
        {
            currentState.FixedUpdateState();
        }
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
    public void Jump()
    {
        if (!jumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        
    }
    public void ChangeState(PState newState)
    {
        if (currentState != null)
        {
            currentState.OnExitState();
        }
        lastState = currentState;
        currentState = newState;
        currentState.OnEnterState(this);
    }
    public void ChangeAnim(string newState)
    {
        if (currentStates == newState) return;

        anim.Play(newState);

        currentStates = newState;
    }
    public void AttackButton()
    {
        ChangeAnim("PlayerIdleAnimation");
        Instantiate(spear, projSpawn.transform.position, Quaternion.identity);
    }
    public void ChangeToFireButtonState()
    {
        ChangeAnim("PlayerThrowAnimation");
    }
    public void ShootSM()
    {
        Instantiate(spear, projSpawn.transform.position, Quaternion.identity);
    }
    void CheckInput()
    {
        if (moveRight)
        {
            dir = 1;
            ChangeState(rightButtonState);
        }
        else if (moveLeft)
        {
            dir = -1;
            ChangeState(leftButtonState);
        }
        else if (!moveRight && !moveLeft && !dead)
        {
            ChangeState(playerIdleState);
        }
        else if(!moveRight && !moveLeft && shooting)
        {
            ChangeState(fireButtonState);
        }
        Debug.DrawRay(transform.position, -Vector2.up * 0.1f, Color.red);
        if(!Physics2D.Raycast(transform.position,-Vector2.up, 0.1f, 1))
        {
            Debug.Log("Off ground");
            if (!lcs.isClimbing && !dead)
            {
                jumping = true;
                ChangeAnim("PlayerJumpAnimation");
            }
            
        }
        else
        {
            jumping = false;
        }
    }
    void HealthCheck()
    {
        //Debug.Log(health);
    }
    public void Death()
    {
        Destroy(gameObject);
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            dead = true;
            ChangeAnim("PlayerDeathAnimation");
            rb.AddForce(Vector2.up * 2, ForceMode2D.Impulse);
            rb.AddForce(Vector2.left * 5, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == 9)
        {
            //Debug.Log("Hit by zombie");
            if(health != 0 || health < 0)
            {
                TakeDamage(1);
            }
            
        }
    }
}
