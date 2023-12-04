using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireButtonState : PState
{
    PlayerStateMachine psm;


    public void OnEnterState(PlayerStateMachine stateMachine)
    {
        psm = stateMachine;
        psm.ChangeAnim("PlayerThrowAniamtion");
    }
    public void UpdateState()
    {

    }
    public void FixedUpdateState()
    {

    }
    public void OnExitState()
    {
        psm.shooting = false;
    }
}
