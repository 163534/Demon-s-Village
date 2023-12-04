using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightButtonState : PState
{
    PlayerStateMachine psm;
    Rigidbody2D rb;
    SpriteRenderer sr;
    public void OnEnterState(PlayerStateMachine stateMachine)
    {
        psm = stateMachine;
        rb = psm.rb;
        sr = psm.sr;
        sr.flipX = false;
        psm.ChangeAnim("PlayerRunAnimation");
    }
    public void UpdateState()
    {
        rb.velocity = new Vector2(1 * psm.speed, rb.velocity.y);
    }
    public void FixedUpdateState()
    {

    }
    public void OnExitState()
    {

    }
}
