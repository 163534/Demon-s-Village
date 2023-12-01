using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isPressed = false;
    GameObject player;
    Rigidbody2D rb;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
    }
    // Called when the button is pressed
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        // Add any additional actions you want to perform when the button is pressed
    }

    // Called when the button is released
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        // Add any additional actions you want to perform when the button is released
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            rb.velocity = new Vector2(1 * 2, rb.velocity.y);
            // Add actions you want to perform while the button is held down
            // For example, move a character, increase a value, etc.
        }
    }
}
