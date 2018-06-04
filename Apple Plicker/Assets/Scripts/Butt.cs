using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butt : MonoBehaviour {

    public GameObject pooPrefab;
    public GameObject fartParticles;

    public float speed = 1f;
    public float force = 400f;
    public float chanceToChangeDirections = 0.1f;
    public float secondsBetweenAppleDrops = 1f;

    float randomNum;
    AudioSource fartnoise; 

    void Start()
    {
        fartnoise= gameObject.GetComponent<AudioSource>();
        // Dropping apples every second
        InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);
    }//Start

    void Update()
    {
        randomNum = Random.Range(-20, 20);
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
        Destroy(Instantiate(fartParticles, gameObject.transform.position, gameObject.transform.rotation) as GameObject, 2);
        fartnoise.Play();
        GameObject plop = Instantiate(pooPrefab, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
        Rigidbody2D rb = plop.GetComponent<Rigidbody2D>();
        rb.AddForce(-plop.transform.up * force);
        rb.AddTorque(randomNum);
        

    }//DropApple


}//Butt Class
