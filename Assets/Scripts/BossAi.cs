using UnityEngine;
using System.Collections;

public class BossAi : MonoBehaviour {

	IBossClass[] classes;

    Random rand = new Random();

    IBossClass currentState;
	// Use this for initialization
	void Start () {
		classes=GetComponentsInChildren<IBossClass>();
        StartCoroutine(AIMovementLoop());
        //attivo in modo scriptato la classe "Tringolo"
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        currentState = classes[0];
    }


    IEnumerator AIMovementLoop()
    {
        while (true)//finchè non muoio
        {
            print("Aspetto");
            //aspetto un tempo random di secondi
            yield return new WaitForSeconds(Random.Range(0.5f, 3f));
            print("fine attesa");
            //decido la direzione e la quantità di spostamento a random
            float delta = Random.Range(-2f, 2f);
            foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>()) {
                sr.flipX = delta > 0 ? true : false;
            }
            //TODO: controllare che il boss non stia uscendo dalla sua zona
            //mi sposto
            Vector2 startPosition = transform.position;
            while(Vector2.Distance(transform.position,startPosition+new Vector2(delta, 0)) > 0.5f)
            {
                transform.position = Vector2.Lerp(transform.position, startPosition + new Vector2(delta, 0), Time.deltaTime * 2);
                yield return new WaitForEndOfFrame();
            }
            print("Fine spostamento");
        }
    }

}
