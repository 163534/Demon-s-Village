using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ChaseState : IState
{
    ZombieScript zs;
    float timer;
    int dirCheck;
    public void OnEnterState(ZombieScript stateMachine)
    {
        zs = stateMachine;
        timer = 0;
        zs.ChangeAnim("ChaseAnimation");
        Debug.Log("Entered Chase State");
        if (zs.transform.position.x > zs.playerPos.position.x)
        {
            dirCheck = 1;
        }
        else if(zs.transform.position.x < zs.playerPos.position.x)
        {
            dirCheck = 0;
        }


    }
    // Start is called before the first frame update
    public void UpdateState()
    {
        Chase();
    }
    public void FixedUpdateState()
    {
        
    }
    public void OnExitState()
    {

    }
    void Chase()
    {
        
        
        if(timer != 8f || timer >= 8f)
        {
            timer += Time.deltaTime;
        }
        if(timer >= 8)
        {
            Debug.Log("Death");
            zs.Death();
        }
        Debug.Log(timer);

        if (dirCheck == 1)
        {
            // if on the left side of the player will move right
            
            zs.rb.velocity = new Vector2(-0.5f, zs.rb.velocity.y);
            zs.transform.localScale = new Vector2(1f, zs.transform.localScale.y);
            
        }
        else if(dirCheck == 0)
        {
            zs.rb.velocity = new Vector2(0.5f, zs.rb.velocity.y);
            zs.transform.localScale = new Vector2(-1f, zs.transform.localScale.y);
        }

        
        
    }
}
