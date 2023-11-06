using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    
    void Update()
    {
        if(Input.anyKeyDown || Input.GetButton("Jump"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
            GameData.ballsInPane = 0;
        }
    }
    
}
