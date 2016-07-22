using UnityEngine;
using System.Collections;
using System;

public class TriangleBossClass : MonoBehaviour,IBossClass {

	float attackCooldownCounter=0;
	public float attackCooldown=10f;

	IBossClass[] classes;

	// Use this for initialization
	void Start () {
		print("waiting for cooldown");
	}
	
	// Update is called once per frame
	void Update () {
		attackCooldownCounter-=Time.deltaTime;
		if(attackCooldownCounter<=0){
			Attack();
			attackCooldownCounter=attackCooldown;//reset cooldown counter
		}
	}

    public void Attack()
    {
        print("Show spuntoni");
    }
}
