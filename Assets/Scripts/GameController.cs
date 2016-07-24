using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public bool isPause = false;
    public bool gameOver = false; 
    public GameObject pauseCanvas;
    public GameObject inGameCanvas;
    public GameObject currentBoss;
    public GameObject gameOverObject;
    public GameObject player;
    public Button mockButton; 
    public int bossType = 0;
    public MainMenuController mainMenuController;
    public GameObject TheVoid; 

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        isPause = false;
        gameOver = false;
        Retry();
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
            GameObject.Find("ReturnToGame").GetComponent<Button>().Select(); 
        }
        else
        {
            mainMenuController.PlaySound();
            Time.timeScale = 1;
            print("Running");
            isPause = false;
            inGameCanvas.SetActive(true);
            pauseCanvas.SetActive(false);
            mockButton.Select(); 
        }
    }

    public void ExitGame()
    {
        Time.timeScale = 1;
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
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Boss"))
            Destroy(g);
        GameObject b =  Instantiate(currentBoss);
        b.SendMessage("Init",bossType,0);
        gameOver = false;
        mockButton.Select();

    }

    public void GameOver()
    {
        gameOver = true;
        gameOverObject.SetActive(true);
        GameObject.Find("Retry").GetComponent<Button>().Select();
    }

    public void TheEnd()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Boss"))
            Destroy(g);
        GameObject.Find("InGame").SetActive(false);
        GameObject.Find("Crosshair").GetComponent<SpriteRenderer>().color = Color.black;
        TheVoid.SetActive(true);
    }
}
