using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerIdleState : PState
{
    PlayerStateMachine psm;
    Rigidbody2D rb;
    public void OnEnterState(PlayerStateMachine stateMachine)
    {
        psm = stateMachine;
        rb = psm.rb;
        psm.ChangeAnim("PlayerIdleAnimation");
    }
    public void UpdateState()
    {
        rb.velocity = new Vector2(rb.velocity.x * 0.5f, rb.velocity.y);
        if (rb.velocity.x > -0.2f && rb.velocity.x < 0.2f)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
    public void FixedUpdateState()
    {

    }
    public void OnExitState()
    {

    }
    
}
