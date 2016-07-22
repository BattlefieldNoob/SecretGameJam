using UnityEngine;
using System.Collections;
using System;

public class CircleClass : MonoBehaviour,IPlayerClass {

	
    public void Attack1()
    {
        print("Circle Class Attack1");
		transform.Translate(new Vector2(1,30));
    }

    public void Attack2()
    {
        print("Circle Class Attack2");
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
