using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour {

    public Text scoreText;

    void Start()
    {
        // Find a reference to the ScoreCounter GameObject
        scoreText = GameObject.Find("ScoreCounter").GetComponent<Text>();                  
        // Set the starting number of points to 0
        scoreText.text = "0";
    }

    void Update ()
    {
        // Get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;                          

        // The Camera's z position sets the how far to push the mouse into 3D
        mousePos2D.z = -Camera.main.transform.position.z;                  

        // Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D); 

        // Move the x position of this Basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // Find out what hit this basket
        if (coll.gameObject.tag == "Poo")
        {                               
            Destroy(coll.gameObject);
        }

        // Parse the text of the scoreGT into an int
        int score = int.Parse(scoreText.text);                             
        // Add points for catching the apple
        score += 100;
        // Convert the score back to a string and display it
        scoreText.text = score.ToString();

    }
}
