using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    public GameObject gun;
    public float shootFrequency = 0.5f;
    float counter;
    public AudioClip[] shotClips;
    AudioSource audio; 

    public bool canShoot = true;

    void Start()
    {
        audio = GetComponent<AudioSource>(); 
    }

	// Update is called once per frame
	void Update () {
        counter += Time.deltaTime; 
        if (counter>=shootFrequency )
        {
            //   print("wewe"); 
            if (Time.timeScale > 0 && canShoot)
            {
                if (Input.GetMouseButton(1) || Input.GetButton("Fire3"))
                {
                    counter = 0;
                    GameObject bullet = (GameObject)Instantiate(Resources.Load("Bullet"), gun.transform.position, Quaternion.identity);
                    audio.clip = shotClips[Random.Range(0,6)];
                    audio.Play(); 
                    bullet.GetComponent<Bullet>().dir = GameObject.Find("Crosshair").transform.position - transform.position;
                }
            }
        }
	}
}
