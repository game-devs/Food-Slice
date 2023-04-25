using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// This Script represents the controller for the logic ui

public class LogicScript : MonoBehaviour
{
    [SerializeField]
    private int playerScore = 0;

    /*    [SerializeField]
        private Text scoreText;*/


    [SerializeField]
    private TMP_Text scoreText;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = "Score:" + playerScore.ToString();
        Debug.Log(scoreText);
    }

    [ContextMenu("Decrease Score")]
    public void DecreaseScore(int scoreToReduce)
    {
        if (playerScore <= 0)
        {
            return;
        }

        playerScore -= scoreToReduce;
        scoreText.text = "Score:" + playerScore.ToString();
        Debug.Log(scoreText);
    }
}
