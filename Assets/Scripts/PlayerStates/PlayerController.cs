using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    GameObject player;
    Rigidbody2D rb;
    public float speed;
    public float jumpForce; 
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
       
    }
    private void Update()
    {
        
    }

    // Update is called once per frame
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    public void Movement()
    {
        rb.velocity = new Vector2(1 * speed, rb.velocity.y);
    }
    
}
