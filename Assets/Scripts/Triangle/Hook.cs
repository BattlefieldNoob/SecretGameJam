using UnityEngine;
using System.Collections;

public class Hook : MonoBehaviour {

    public GameObject player;
    public bool hooked = false;
    Vector2 dir;
    public int speed; 
	
	// Update is called once per frame
	void Update () {
        if (hooked)
        {
            player.GetComponent<Rigidbody2D>().AddForce(dir.normalized * speed);  
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Ceiling")
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            hooked = true;
            dir = transform.position - player.transform.position;
        }
    }
}
