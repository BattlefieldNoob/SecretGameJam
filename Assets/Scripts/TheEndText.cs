using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TheEndText : MonoBehaviour {

    public RawImage image;
    bool doing; 

	// Use this for initialization
	void Start () {
	    
	}
	
    void DoIt()
    {
        doing = true; 
    }

	// Update is called once per frame
	void Update () {
        if (doing)
        {
            Color c = image.color;
            c.a += 0.01f;
            image.color = c;
            if (c.a >= 1)
                StartCoroutine(BackToMainScreen());
        }

        
	}

    IEnumerator BackToMainScreen()
    {
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(0); 
    }
}
