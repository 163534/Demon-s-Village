using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform followObject;
    public GameObject enemy;
    Camera cam;
    
    float spawnX;
    float spawnY;
    float spawnX2;
    float spawnY2;
    float timer;
    public float timerDelay;
    public float timerDelay2;

    private void Start()
    {
        cam = Camera.main;
        timerDelay = Random.Range(6f, 12f);
    }
    private void Update()
    {
        Vector3 pos = new Vector3(Mathf.Clamp(followObject.position.x, -15.9f, 15.9f), transform.position.y, transform.position.z);
        transform.position = pos;

        timer += Time.deltaTime;

        if (timer >= timerDelay)
        {
            SpawnEnemies(1f + 0.15f, 0.15f);
            SpawnEnemies(0f + -0.15f, 0.15f);
            timer = 0;
        }
        
            
    }
    void SpawnEnemies(float spawnX, float spawnY)
    {
        Vector2 spawnPosition1 = cam.ViewportToWorldPoint(new Vector3(spawnX, spawnY, 0));
        
        Instantiate(enemy, spawnPosition1, Quaternion.identity);
        
    }
}