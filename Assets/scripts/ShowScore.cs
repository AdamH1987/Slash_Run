using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour
{
    public TextMeshProUGUI HIGHSCOREText;
    public TextMeshProUGUI gamesPlayed;
    float playerScore;
    float gamePlay;


    public void Start()
    {
        if (PlayerPrefs.HasKey("playerScore") == true)
        {
            playerScore = PlayerPrefs.GetFloat("playerScore");
        }

        if (PlayerPrefs.HasKey("gamePlay") == true)
        {
            gamePlay = PlayerPrefs.GetFloat("gamePlay");
        }

    }
    public void Update()
    {

        if (Input.GetKeyDown("="))
        {
            playerScore = playerScore + 20;
        }

        if (Input.GetKeyDown("-"))
        {
            playerScore = playerScore - 20;
        }


        HIGHSCOREText.text = "HIGHSCORE: " + playerScore.ToString();
        print("score is " + playerScore);

        PlayerPrefs.SetFloat("playerScore", playerScore);


        float i = 0;

        while (i < 10000000)
        {
            gamesPlayed.text = "Game as been played: " + gamePlay.ToString() + " times!";
            if (Input.GetKeyDown("g"))
            {
                i++;
            }
            PlayerPrefs.SetFloat("gamePlay", gamePlay);

        }



    }
}
