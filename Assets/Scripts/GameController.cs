using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    bool isPause = false;

    public GameObject pauseCanvas;
    public GameObject inGameCanvas;


	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown("joystick button 7"))
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
        SceneManager.LoadScene(0); 
    }

    public void FirstBossCleared()
    {
        print("Congratulations");
    }
}
