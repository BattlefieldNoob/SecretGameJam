using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour {

    public float hp = 30; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Damage()
    {
        hp--;
        if (hp == 0)
            Destroy(gameObject); 
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Boss" || coll.gameObject.tag == "Pikes")
            Damage(); 
    }
}
