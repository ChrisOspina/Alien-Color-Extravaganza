using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorPane : MonoBehaviour
{
    public string whatColor;
    public TMP_Text scoreText;
    //public TMP_Text livesText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Ball ball = other.GetComponent<Ball>();
            if(ball != null && ball.ballColor == whatColor)
            {
                GameData.ballsInPane++;
                GameData.score += 5;
                scoreText.text = "Score : " + GameData.score.ToString();
                CheckIfAllBallsInPane();
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Ball ball = other.GetComponent<Ball>();
            if (ball != null && ball.ballColor == whatColor)
            {
                GameData.ballsInPane--;

                if(GameData.score>=5)
                    GameData.score -= 5;
                    scoreText.text = "Score : " + GameData.score.ToString();

            }
           
        }
    }

    private void CheckIfAllBallsInPane()
    {
        if(GameData.ballsInPane == 4)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Win");
        }
        else
        {
            return;
        }
    }
}



