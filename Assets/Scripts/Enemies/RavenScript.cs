using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RavenScript : MonoBehaviour
{
    Rigidbody2D rb;
    LayerMask playerMask;
    public float detectDis;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMask = LayerMask.GetMask("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CheckForPlayer();
    }
    void CheckForPlayer()
    {
        Debug.DrawRay(transform.position, transform.forward * detectDis);
        if(Physics2D.Raycast(transform.position, transform.forward, detectDis, playerMask))
        {
            Debug.Log("Player Detected");
        }
    }
    void Movement()
    {
        
    }
}
