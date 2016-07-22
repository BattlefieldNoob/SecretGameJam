using UnityEngine;
using System.Collections;

public class Square : MonoBehaviour {

    public float speed;
    public float destroyTime;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, destroyTime);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(0, -Time.deltaTime * speed,0);
	}
}
