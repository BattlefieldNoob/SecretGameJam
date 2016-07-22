using UnityEngine;
using System.Collections;

public class BossAi : MonoBehaviour {

	IBossClass[] classes;

	// Use this for initialization
	void Start () {
		classes=GetComponentsInChildren<IBossClass>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
