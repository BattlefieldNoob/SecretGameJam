using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public bool isPause = false;
    public bool gameOver = false; 
    public GameObject pauseCanvas;
    public GameObject inGameCanvas;
    public GameObject currentBoss;
    public GameObject gameOverObject;
    public GameObject player;
    public int bossType = 0; 


	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
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
        Instantiate(player, new Vector3(-80.7f, 0, 0), Quaternion.identity);
        gameOverObject.SetActive(false);
        Destroy(GameObject.Find("Boss"));
        GameObject b =  Instantiate(currentBoss);
        b.SendMessage("Init",bossType,0); 
            
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverObject.SetActive(true); 
    }
}
