using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButtonState : PState
{
    PlayerStateMachine psm;
    Rigidbody2D rb;
    SpriteRenderer sr;
    
    public void OnEnterState(PlayerStateMachine stateMachine)
    {
        psm = stateMachine;
        rb = psm.GetComponent<Rigidbody2D>();
        sr = psm.sr;
        psm.ChangeAnim("PlayerRunAnimation");
        sr.flipX = true;
    }
    public void UpdateState()
    {

        rb.velocity = new Vector2(-1 * psm.speed, rb.velocity.y);
    }
    public void FixedUpdateState()
    {
    
    }
    public void OnExitState()
    {

    }
}
