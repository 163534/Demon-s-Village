using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public Transform bulletSpawnPos;
    Animator anim;
    float playerDist;
    public float detectDis;
    bool shooting;
    float timer;
    public float timerLimit;
    string currentStates;
    // Start is called before the first frame update
    void Start()
    {
        shooting = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerDist = Vector2.Distance(gameObject.transform.position, player.transform.position);
        timer += Time.deltaTime;
        //Debug.Log("Shooting = " + shooting);

        if(playerDist <= detectDis)
        {
            ChangeAnim("PlantAttackAnimation");
        }
        else
        {
            ChangeAnim("PlantIdleAnimation");
            return;
        }
        
    }
    public void Death()
    {
        Destroy(gameObject);
    }
    public void Shoot()
    {
        Instantiate(bullet, bulletSpawnPos.position, Quaternion.identity);
    }
    public void ChangeAnim(string newState)
    {
        if (currentStates == newState) return;

        anim.Play(newState);

        currentStates = newState;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 8)
        {
            ChangeAnim("PlantDeathAnimation");
            //Destroy
        }
    }
}
