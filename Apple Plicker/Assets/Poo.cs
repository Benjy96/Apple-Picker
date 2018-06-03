using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poo : MonoBehaviour {

    public static float bottomY = -20f;



    void Update()
    {
        if (transform.position.y < bottomY)
        {
            GameManager gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
            gameManager.PooDestroyed();
            Destroy(gameObject);
            
        }
    }//Update
}
