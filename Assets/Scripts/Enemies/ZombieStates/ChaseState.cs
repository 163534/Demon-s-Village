using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ChaseState : IState
{
    ZombieScript zs;
    float timerLimit;
    float timer;
    int dirCheck;
    int select;
    public void OnEnterState(ZombieScript stateMachine)
    {
        zs = stateMachine;
        timer = 0;
        timerLimit = Random.Range(6f, 10f);
        select = 0;
        zs.ChangeAnim("ChaseAnimation");
        //Debug.Log("Entered Chase State");
        if (zs.transform.position.x > zs.playerPos.transform.position.x)
        {
            dirCheck = 1;
        }
        else if(zs.transform.position.x < zs.playerPos.transform.position.x)
        {
            dirCheck = 0;
        }


    }
    // Start is called before the first frame update
    public void UpdateState()
    {
        switch (select)
        {
            case 0:
                Chase();
                break;
            case 1:
                Despawn();
                break;

        }

        
    }
    public void FixedUpdateState()
    {
        
    }
    public void OnExitState()
    {

    }
    void Chase()
    {
        if(timer != timerLimit || timer >= timerLimit)
        {
            timer += Time.deltaTime;
        }
        if(timer >= timerLimit)
        {
            select = 1;
        }
        //Debug.Log(timer);

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
    void Despawn()
    {
        
            //Debug.Log("Death");

            zs.rb.velocity = new Vector2(0f, zs.rb.velocity.y);
            zs.ChangeAnim("DespawnAnimation");
        
    }
}
