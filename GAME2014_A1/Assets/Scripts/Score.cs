/*
Score - GAME2014-A1P2-[100753770]
Harrison Black, 100753770
Last modified - Oct. 23, 2021 
Sets the score text 

Revision History
Oct. 24, 2021 - all code.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text score;
    static int scoreCount = 0;
    public int scoreHolder;
    void Start()
    {
        score = GetComponent<Text>();
        scoreHolder = scoreCount;
        resetScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreHolder >= 100)
            score.text = "YOU WIN! Score: " + scoreHolder;
        else
            score.text = "Score: " + scoreHolder;
    }
    //setter for adding points from outside
    public void addScore(int points)
    {
        scoreCount += points;
        if (scoreCount < 100)
            scoreHolder = scoreCount;
        else
        {
            GameObject.FindGameObjectWithTag("Audio").GetComponent<soundScript>().switchTunes(3);
            SceneManager.LoadScene("Game Over");
        }
    }
    //reset static score when replay
    public void resetScore()
    {
        scoreCount = 0;
    }
}
