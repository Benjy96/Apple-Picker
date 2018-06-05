using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour {

    public float speed = 30f;

    AudioSource audio;
    
    private void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }

    void Update ()
    {
#if UNITY_STANDALONE || UNITY_WEBPLAYER

        // Get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;                          

        // The Camera's z position sets the how far to push the mouse into 3D
        mousePos2D.z = -Camera.main.transform.position.z;                  

        // Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D); 

        // Move the x position of this Basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * speed);

#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        bool move = false;
        if (Input.acceleration.x > 0 || Input.acceleration.x < 0) move = true;

        if (move) transform.position = Vector2.Lerp(transform.position,
             new Vector2(transform.position.x + Input.acceleration.x, transform.position.y),
             Time.deltaTime * speed);
        //transform.Translate(Input.acceleration.x, 0f, 0f);
#endif
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // Find out what hit this basket
        if (coll.gameObject.tag == "Poo")
        {

            GameManager gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
            gameManager.currentScore += 100;
            audio.Play();
            Destroy(coll.gameObject);
        }//if

    }
}
