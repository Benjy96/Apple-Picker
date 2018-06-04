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
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        //print("screen pos "+screenPos.x);
        //print("Screen width " + Screen.width);

        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Changing Direction
        if (screenPos.x < 0)
        {
            speed = Mathf.Abs(speed);  // Move right
        }
        else if (screenPos.x > Screen.width)
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
        Rigidbody2D rb = apple.GetComponent<Rigidbody2D>();
        rb.AddForce(apple.transform.forward * 200f);
        apple.transform.position = transform.position;

    }//DropApple


}//Butt Class
