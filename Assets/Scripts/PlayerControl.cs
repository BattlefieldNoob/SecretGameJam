using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour {

	List<IPlayerClass> classes=new List<IPlayerClass>();

	IPlayerClass current;

	int currentIndex=0;

	// Use this for initialization
	void Start () {
		classes.Add(new TriangleClass());
		classes.Add(new CircleClass());
		current=classes[0];
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.F)){
			current.Attack1();
		}else if (Input.GetKeyDown(KeyCode.G)){
			current.Attack2();
		}else if (Input.GetKeyDown(KeyCode.T)){
			//switch state 
			int nextState = currentIndex+1;
			print(nextState);
			currentIndex=nextState<classes.Count?nextState:0;
			current = classes[currentIndex];
			print("next Position:"+currentIndex);
			//TODO: gestire la trasformazione della forma del personaggio
			print("switched state");
		}
	}
}
