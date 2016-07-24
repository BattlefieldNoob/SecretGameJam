using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    public AudioSource audio;

    public AudioClip[] clips;

    AudioSource[] soundTracks;

        // Use this for initialization
    void Start () {
       soundTracks = GameObject.Find("SoundTracks").GetComponents<AudioSource>();
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
        if (scene == 1)
        {
            soundTracks[1].Play();
            while (soundTracks[1].volume <= 0.9f)
            {
                soundTracks[0].volume = Mathf.Lerp(soundTracks[0].volume, 0, Time.deltaTime * 2f);
                soundTracks[1].volume = Mathf.Lerp(soundTracks[1].volume, 1, Time.deltaTime * 2f);
                yield return new WaitForEndOfFrame();
            }
            soundTracks[1].volume = 1f;
            soundTracks[0].Stop();
        }
        else if (scene == 0)
        {
            if (!soundTracks[0].isPlaying) 
                soundTracks[0].Play();
            else
                yield return new WaitForSeconds(audio.clip.length);
            while (soundTracks[0].volume <= 0.9f)
            {
                soundTracks[1].volume = Mathf.Lerp(soundTracks[1].volume, 0, Time.deltaTime * 2f);
                soundTracks[0].volume = Mathf.Lerp(soundTracks[0].volume, 1, Time.deltaTime * 2f);
                yield return new WaitForEndOfFrame();
            }
            soundTracks[0].volume = 1f;
            soundTracks[1].Stop();
        }
        else
        {
            yield return new WaitForSeconds(audio.clip.length);
        }
        SceneManager.LoadScene(scene);
    }
}
