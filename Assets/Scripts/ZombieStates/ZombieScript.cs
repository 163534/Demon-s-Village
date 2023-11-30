using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public void UpdateState();
    public void FixedUpdateState();
    public void OnEnterState(ZombieScript zs);
    public void OnExitState();
}
public class ZombieScript : MonoBehaviour
{
    public IState currentState, lastState;
    public SpawnState spawnState = new SpawnState();
    public ChaseState chaseState = new ChaseState();
    public DeathState deathState = new DeathState();


    [SerializeField]
    public GameObject playerPos;
    public Rigidbody2D rb;
    public Animator anim;
    private string currentStates;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerPos = GameObject.FindGameObjectWithTag("Player");
        
        ChangeState(spawnState);
    }

    // Update is called once per frame
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == 7)
        {

        }
    }
    public void ChangeState(IState newState)
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
    public void ChangeToChase()
    {
        ChangeState(chaseState);
    }
    public void Death()
    {
        Destroy(gameObject);
    }

}
