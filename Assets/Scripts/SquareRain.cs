using UnityEngine;
using System.Collections;

public class SquareRain : MonoBehaviour {

    public float maxLenghtOfInstantiation;

    public int maxFallingSquares;

    int instantiatedSquares = 0;

    public GameObject squareToClone;

	void Start()
    {
        StartCoroutine(SquareRainRoutine());
    }

    IEnumerator SquareRainRoutine()
    {
        float lastRandomX=0;
        while (instantiatedSquares < maxFallingSquares)
        {
            //scelgo una posizione casuale per instanziare il cubo        
            float x = Random.Range(-maxLenghtOfInstantiation, maxLenghtOfInstantiation);

            while (instantiatedSquares > 0 && Mathf.Abs(x-lastRandomX) < 2f)//evito che due cubi consecutivi escano vicini
            {
                print("too Close");
                x = Random.Range(-maxLenghtOfInstantiation, maxLenghtOfInstantiation);
            }

            Instantiate(squareToClone, new Vector2(x, transform.position.y), Quaternion.identity);

            lastRandomX = x;

            instantiatedSquares++;

            yield return new WaitForSeconds(Random.Range(0.3f, 1f));//aspetto un tempo random, quindi instanzio altri quadrati
        }
        Destroy(gameObject);
        yield break;
    }
}
