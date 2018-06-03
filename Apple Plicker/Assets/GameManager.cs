using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {




    public GameObject basketPrefab;
    public GameObject gameOver;
    public List<GameObject> basketList;
    public Text scoreText;
    public Text highScoreText;
    

    public int numBaskets = 3;
    public int highScore;
    public int currentScore;
    public float basketBottomY = -14f;
    public float basketSpacingY = 1f;


    void Awake()
    {                                                        
        // If the ApplePickerHighScore already exists, read it
        if (PlayerPrefs.HasKey("ApplePickerHighScore"))
        {                  
            highScore = PlayerPrefs.GetInt("ApplePickerHighScore");
        }
        // Assign the high score to ApplePickerHighScore
        PlayerPrefs.SetInt("ApplePickerHighScore", highScore);                
    }



    void Start()
    {
        scoreText = GameObject.Find("ScoreCounter").GetComponent<Text>();
        highScoreText = GameObject.Find("HighScore").GetComponent<Text>();

        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate(basketPrefab) as GameObject;
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    private void Update()
    {
        scoreText.text = "Score "+ currentScore.ToString();
        highScoreText.text = "High Score "+ highScore.ToString();

        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("ApplePickerHighScore", highScore);
        }

  
    }


    public void PooDestroyed()
    {                                         
        // Destroy all of the falling Poos
        GameObject[] pooArray = GameObject.FindGameObjectsWithTag("Poo");
        foreach (GameObject poo in pooArray)
        {
            Destroy(poo);
        }//foreach

        // Destroy one of the Baskets
        // Get the index of the last Basket in basketList
        int basketIndex = basketList.Count - 1;
        // Get a reference to that Basket GameObject
        GameObject tBasketGO = basketList[basketIndex];
        // Remove the Basket from the List and destroy the GameObject
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);


        // Restart the game, which doesn't affect HighScore.Score
        if (basketList.Count == 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Time.timeScale = 0;
        gameOver.SetActive(true);

        

        //show high score and current score in bold
        //give options to quit and restart
        //reset current score and basket count
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("ApplePickerHighScore", 0);
        highScoreText.text = "High Score " + highScore.ToString();
    }

}
