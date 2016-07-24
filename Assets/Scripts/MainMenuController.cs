using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    public AudioSource audio;

    public AudioClip[] clips; 

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnStart()      
    {
        StartCoroutine(OnClickSound(1));
    }

    public void OnTutorial()
    {
        StartCoroutine(OnClickSound(2));
    }

    public void OnCredits()
    {
        StartCoroutine(OnClickSound(3));
    }

    public void OnBack()
    {
        StartCoroutine(OnClickSound(0));

    }

    public void PlaySound()
    {
        audio.clip = clips[1];
        audio.Play();
    }

    public void OnHover()
    {
        audio.clip = clips[0];
        audio.Play();
    }

    public IEnumerator OnClickSound(int scene)
    {
        audio.clip = clips[1];
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        SceneManager.LoadScene(scene);
    }
}
