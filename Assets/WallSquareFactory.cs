using UnityEngine;
using System.Collections;

public class WallSquareFactory : MonoBehaviour {

    WallSquare[] wallSquares;

    public Vector2 hiddenPosition;
    Transform bossTransform;
	// Use this for initialization
	void Start () {
        wallSquares = GetComponentsInChildren<WallSquare>();
        int i = 0;
        foreach(WallSquare square in wallSquares)
        {
            square.correctPosition = square.transform.position;//salvo la posizione corretta per ogni quadrato
            square.transform.position = hiddenPosition+new Vector2(i++*30,0);
        }
        bossTransform = GameObject.FindGameObjectWithTag("Boss").transform;
        StartCoroutine(CleanArray());
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = bossTransform.position;   
	}

    IEnumerator CleanArray()
    {
        while (wallSquares.Length > 0)
        {
            wallSquares = GetComponentsInChildren<WallSquare>();//ottengo i pezzi di muro restanti
            yield return new WaitForSeconds(0.5f);
        }
        bossTransform.GetComponent<BossAi>().currentState = BossAi.States.Free;
        Destroy(gameObject);
    }
}
