using UnityEngine;
using System.Collections;

public class Hook : MonoBehaviour {

    public GameObject player;
    public bool hooked = false;
    Vector2 dir;
    public int speed;
    LineRenderer lr; 
	

    void Start()
    {
        lr = GetComponentInChildren<LineRenderer>();
        lr.SetPosition(0, player.transform.position); 
    }

	// Update is called once per frame
	void Update () {
        lr.SetPosition(0, player.transform.position);
        lr.SetPosition(1, transform.position);
        if (hooked)
        {
            player.GetComponent<Rigidbody2D>().AddForce(dir.normalized * speed);
        }
       
           
        
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Ceiling" || coll.gameObject.name.StartsWith("Floor"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            hooked = true;
            dir = transform.position - player.transform.position;
        }
    }
}
