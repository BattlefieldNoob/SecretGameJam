using UnityEngine;
using System.Collections;

public class Hook : MonoBehaviour {

    public GameObject player;
    public bool hooked = false;
    Vector2 dir;
    public int speed;
    LineRenderer lr;

    AudioSource hookSounds;

    public AudioClip hookPulled;
    public AudioClip hookReleased;

    void Start()
    {
        lr = GetComponentInChildren<LineRenderer>();
        lr.SetPosition(0, player.transform.position);

        hookSounds = GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void Update () {
        if (Time.timeScale != 0)
        {
            if (player == null)
                Destroy(lr);
            if (player != null)
            {
                lr.SetPosition(0, player.transform.position);
                lr.SetPosition(1, transform.position);
                if (hooked)
                {
                    player.GetComponent<Rigidbody2D>().AddForce(dir.normalized * speed);
                }
            }

        } 
        
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Ceiling" || coll.gameObject.name.StartsWith("Floor"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            hooked = true;
            hookSounds.clip = hookPulled;
            hookSounds.Play();
            dir = transform.position - player.transform.position;
        }
    }
}
