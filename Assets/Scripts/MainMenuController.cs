using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnStart()
    {
        SceneManager.LoadScene(1);
    }

    public void OnTutorial()
    {
        SceneManager.LoadScene(2);
    }

    public void OnCredits()
    {

    }
}
