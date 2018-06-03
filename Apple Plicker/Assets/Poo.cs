using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poo : MonoBehaviour {

    public static float bottomY = -20f;



    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(gameObject);
            GameManager.instance.PooDestroyed();
        }
    }//Update
}
