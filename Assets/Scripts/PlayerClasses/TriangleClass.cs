using UnityEngine;
using System.Collections;
using System;

public class TriangleClass : MonoBehaviour, IPlayerClass {

    void IPlayerClass.Attack1()
    {
        print("Triangle Class Attack1");
    }

    void IPlayerClass.Attack2()
    {
        print("Triangle Class Attack2");
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
