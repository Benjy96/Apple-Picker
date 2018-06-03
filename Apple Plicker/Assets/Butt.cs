using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butt : MonoBehaviour {

    // Prefab for instantiating poos
    public GameObject pooPrefab;

    // Speed at which the AppleTree moves in meters/second
    public float speed = 1f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change directions
    public float chanceToChangeDirections = 0.1f;

    // Rate at which Apples will be instantiated
    public float secondsBetweenAppleDrops = 1f;

    void Start()
    {
        // Dropping apples every second
        InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);
    }//Start

    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);  // Move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // Move left
        }

    }//Update

    void FixedUpdate()
    {
        // Changing Direction Randomly
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;  // Change direction
        }
    }//FixedUpdate

    void DropApple()
    {
        GameObject apple = Instantiate(pooPrefab) as GameObject;
        apple.transform.position = transform.position;
    }//DropApple


}//Butt Class
