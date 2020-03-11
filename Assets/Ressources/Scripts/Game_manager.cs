using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_manager : MonoBehaviour
{

    bool hasEnded = false;
    float delayRestart = 0.2f;
   public void Endgame()
    {
        if(hasEnded == false)
        {
            hasEnded = true;
            Invoke("Restart", delayRestart);
        }
    }

    public void Restart()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
