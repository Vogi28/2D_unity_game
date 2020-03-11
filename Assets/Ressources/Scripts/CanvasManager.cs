using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{

    public GameObject pausePanel;
    private bool isPause = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            pausePlay();
        }
    }

    public void pausePlay()
    {
        if(isPause)
        {
            isPause = false;
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
        else
        {
            isPause = true;
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
    }
}
