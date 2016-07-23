using UnityEngine;
using System.Collections;

public class BossAi : MonoBehaviour {

    enum Classes { Square, Triangle };

    public enum States { Free, Frozen }

    Classes currentClass;
    public States currentState;
    GameObject current;

    public HealthBarScript healthBar;
    AudioSource audio;
    public AudioClip[] hitClips; 
	 // Use this for initialization
	void Start () {
        //StartCoroutine(AIMovementLoop());
        //attivo in modo scriptato la classe "Square"
        transform.GetChild(1).gameObject.SetActive(false);
        current = transform.GetChild(0).gameObject;
        currentClass = Classes.Square;
        healthBar.MaxValue = current.GetComponent<IBossClass>().getHP();
        audio = GetComponent<AudioSource>(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))//TODO:da rimuovere, ci pensa l'AI
        {
            SwitchClass();
        }
        healthBar.Value = current.GetComponent<IBossClass>().getHP();
    }

    public void Damage()
    {
        current.SendMessage("Damage");
        audio.clip = hitClips[Random.Range(0,4)];
        audio.Play(); 
    }


    public void PyramidDeath()
    {
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(0).gameObject.SetActive(false);
        current = transform.GetChild(1).gameObject;
        current.transform.position = new Vector3(0, current.transform.position.y, 0);
        healthBar.MaxValue = current.GetComponent<IBossClass>().getHP();
        currentClass = Classes.Triangle;
    }

    public void OctahedronDeath()
    {
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
        current = transform.GetChild(2).gameObject;
        current.transform.position = new Vector3(0, current.transform.position.y, 0);
        healthBar.MaxValue = current.GetComponent<IBossClass>().getHP();
        currentClass = Classes.Triangle;
    }

    public void CubeDeath()
    {

    }

    void SwitchClass()
    {
        switch (currentClass)
        {
            case Classes.Square:
                {
                    //disattivo tutti, attivo la classe square
                    transform.GetChild(1).gameObject.SetActive(true);
                    transform.GetChild(0).gameObject.SetActive(false);
                    current = transform.GetChild(1).gameObject;
                    healthBar.MaxValue = current.GetComponent<IBossClass>().getHP();
                    currentClass = Classes.Triangle;
                }
                break;
            case Classes.Triangle:
                {
                    //disattivo tutti, attivo la classe square
                    transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(0).gameObject.SetActive(true);
                    current = transform.GetChild(0).gameObject;
                    healthBar.MaxValue = current.GetComponent<IBossClass>().getHP();
                    currentClass = Classes.Square;
                }
                break;
        }
    }


    IEnumerator AIMovementLoop()
    {
        while (true)//finchè non muoio
        {
            if (currentState != States.Frozen)
            {
                print("Aspetto");
                //aspetto un tempo random di secondi
                yield return new WaitForSeconds(Random.Range(0.5f, 2f));
                print("fine attesa");
                //decido la direzione e la quantità di spostamento a random
                float delta = Random.Range(-2f, 2f) * 15;
                foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
                {
                    sr.flipX = delta > 0 ? true : false;
                }
                //TODO: controllare che il boss non stia uscendo dalla sua zona
                //mi sposto
                Vector2 startPosition = transform.position;
                while (Vector2.Distance(transform.position, startPosition + new Vector2(delta, 0)) > 1f)
                {
                    transform.position = Vector2.Lerp(transform.position, startPosition + new Vector2(delta, 0), Time.deltaTime * 2);
                    yield return new WaitForEndOfFrame();
                }
                print("Fine spostamento");
            }else
            {
                yield return new WaitForSeconds(4f);
            }
        }
    }

}
