using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform followObject;
    
    private void Update()
    {
        Vector2 pos = new Vector2(Mathf.Clamp(followObject.position.x, -15.9f, 15.9f), transform.position.y);
        transform.position = pos;
    }
}