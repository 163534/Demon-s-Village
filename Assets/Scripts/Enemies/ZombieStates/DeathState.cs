using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : IState
{
    ZombieScript zs;
    public void OnEnterState(ZombieScript stateMachine)
    {
        zs = stateMachine;
        zs.ChangeAnim("DeathAnimation");
        
    }
    // Start is called before the first frame update
    public void UpdateState()
    {

    }
    public void FixedUpdateState()
    {

    }
    public void OnExitState()
    {

    }
}
