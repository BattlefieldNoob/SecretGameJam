using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float speed;
    public float ttl = 3;
    float timeLived = 0;
    public Vector2 dir; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timeLived += Time.deltaTime;
        if (timeLived >= ttl)
            Destroy(gameObject);
        transform.position += (Vector3)dir.normalized * Time.deltaTime * speed; 
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "WeakPoint")
            coll.gameObject.SendMessage("Damage"); 
    }
}
