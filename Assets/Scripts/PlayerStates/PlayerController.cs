using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public interface PState
{
    public void UpdateState();
    public void FixedUpdateState();
    public void OnEnterState(PlayerController pc);
    public void OnExitState();
}
public class PlayerController : MonoBehaviour
{
    public PState currentState, lastState;


    Rigidbody2D rb;
    GameObject zombie;
    float horizontal;
    float vertical;
    public float speed;
    public float jumpForce; 
    
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState();
        }
        Debug.Log(currentState);
    }
    private void FixedUpdate()
    {
        if (currentState != null)
        {
            currentState.FixedUpdateState();
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
    // Update is called once per frame
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        
    }
    void Movement()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

    }
    
}
