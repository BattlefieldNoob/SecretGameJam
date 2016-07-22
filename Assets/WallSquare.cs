using UnityEngine;
using System.Collections;

public class WallSquare : MonoBehaviour {
    public Vector2 correctPosition;//posizione corretta per ogni quadrato per comporre il muro

    public Vector2 delta;

    public Transform boss;

    public float speed = 2;
    // Use this for initialization
    void Start () {
        if (correctPosition!=null)
        {
            StartCoroutine(MakeWall());//faccio spostare questo pezzo di muro nella sua posizione corretta
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator MakeWall()
    {
        while (Vector2.Distance(transform.position, correctPosition) > 0.1f)
        {
            transform.position = Vector2.Lerp(transform.position, correctPosition, Time.deltaTime * speed);
            yield return new WaitForEndOfFrame();
            correctPosition = (Vector2)boss.position - delta;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<Bullet>())
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
    }
}
