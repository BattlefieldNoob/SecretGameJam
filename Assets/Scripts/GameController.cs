using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    bool isPause = false;

    public GameObject pauseCanvas;
    public GameObject inGameCanvas;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.P))
        {
            SwitchPause();
        }
	}

    public void SwitchPauseButton()
    {
        SwitchPause();
    }

    void SwitchPause()
    {
        if (!isPause)
        {
            Time.timeScale = 0;
            print("Pause");
            isPause = true;
            inGameCanvas.SetActive(false);
            pauseCanvas.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            print("Running");
            isPause = false;
            inGameCanvas.SetActive(true);
            pauseCanvas.SetActive(false);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void FirstBossCleared()
    {
        print("Congratulations");
    }
}
