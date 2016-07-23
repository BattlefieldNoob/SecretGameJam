using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public bool isPause = false;
    public bool gameOver = false; 
    public GameObject pauseCanvas;
    public GameObject inGameCanvas;
    public string lastBossEncountered;
    public GameObject gameOverObject;
    public GameObject player; 

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        lastBossEncountered = null;
        isPause = false;
        gameOver = false; 
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
        if (!isPause && !gameOver)
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

    public void Retry()
    {
        Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
        if (lastBossEncountered == "Pyramid")
        {
            GameObject.Find("Boss").SendMessage("RetryPyramid");
            Instantiate(player, new Vector3(0,0,0), Quaternion.identity); 
        }
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverObject.SetActive(true); 
    }
}
