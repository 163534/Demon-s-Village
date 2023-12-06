using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnState : IState
{
    ZombieScript zs;
    int dirCheck;
    public void OnEnterState(ZombieScript stateMachine)
    {
        zs = stateMachine;
        zs.ChangeAnim("SpawnAnimation");
        //Debug.Log("Entered Spawn State");
        if (zs.transform.position.x > zs.playerPos.transform.position.x)
        {
            zs.transform.localScale = new Vector2(1f, zs.transform.localScale.y);
        }
        else if (zs.transform.position.x < zs.playerPos.transform.position.x)
        {
            zs.transform.localScale = new Vector2(-1f, zs.transform.localScale.y);
        }
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
