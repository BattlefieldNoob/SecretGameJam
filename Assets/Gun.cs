using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    public GameObject gun;
    public float shootFrequency = 0.5f;
    float counter; 

	// Update is called once per frame
	void Update () {
        counter += Time.deltaTime; 
        if (counter>=shootFrequency )
        {
            print("wewe"); 
            if (Input.GetMouseButtonDown(0) ||Input.GetButton("Fire3"))
            {
                counter = 0;
                GameObject bullet = (GameObject)Instantiate(Resources.Load("Bullet"), gun.transform.position, Quaternion.identity);
                bullet.GetComponent<Bullet>().dir = GameObject.Find("Crosshair").transform.position - transform.position;
            }
        }
	}
}
