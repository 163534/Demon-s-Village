using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    Animator anim;
    public Rigidbody2D rb;
    public GameObject projSpawn;
    public GameObject spear;
    public SpriteRenderer sr;
    private string currentStates;
    public bool moveLeft;
    public bool moveRight;
    public bool shooting;
    public float speed;
    public float jumpForce;
    public int dir;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
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
        Debug.Log(currentState);
        Debug.Log(shooting);
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
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
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
        else if (!moveRight && !moveLeft)
        {
            ChangeState(playerIdleState);
        }
        else if(!moveRight && !moveLeft && shooting)
        {
            ChangeState(fireButtonState);
        }
    }
}
