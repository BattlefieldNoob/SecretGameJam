﻿using UnityEngine;
using System.Collections;

public class Hooker : MonoBehaviour {
    private bool inAir = false;
    public int speed = 100;
    Vector2 direction = Vector2.zero;
    GameObject hookInstance; 
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            if(direction==Vector2.zero)
                direction = GameObject.Find("Crosshair").transform.position - transform.position;
            if (hookInstance == null)
                hookInstance = (GameObject)Instantiate(Resources.Load("Hook"),transform.position + new Vector3(0,10,0),Quaternion.identity); 
            if(!hookInstance.GetComponent<Hook>().hooked)
                hookInstance.GetComponent<Rigidbody2D>().velocity = direction.normalized * Time.deltaTime * speed;
            hookInstance.GetComponent<Hook>().player = transform.parent.gameObject; 
        }
        else
        {
            if(hookInstance!=null)
                Destroy(hookInstance);
            direction = Vector2.zero; 
        }

	}
}