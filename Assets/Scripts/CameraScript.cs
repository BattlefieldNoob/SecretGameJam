using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public float duration;
    public float magnitude;
    bool shaking = false;
    bool canShake = true;
    float count;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!canShake)
        {
            count += Time.deltaTime; 
            if(count>=4)
            {
                canShake = true;
                count = 0; 
            }
        }
	}

    public void StartShaking()
    {
        if(!shaking && canShake)
            StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        GetComponent<AudioSource>().Play(); 
        shaking = true; 
        float elapsed = 0.0f;

        Vector3 originalCamPos = Camera.main.transform.position;

        while (elapsed < duration)
        {

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= magnitude * damper;
            y *= magnitude * damper;

            Camera.main.transform.position = new Vector3(x, originalCamPos.y, originalCamPos.z);
            
            yield return null;
        }
        
        Camera.main.transform.position = originalCamPos;
        shaking = false;
        canShake = false;
    }
}
