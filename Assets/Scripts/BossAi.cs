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
    public GameObject gameController;

	 // Use this for initialization
	void Start () {
        //StartCoroutine(AIMovementLoop());
        //attivo in modo scriptato la classe "Square"
        //transform.GetChild(1).gameObject.SetActive(false);
        //current = transform.GetChild(0).gameObject;
        //currentClass = Classes.Square;
        //healthBar.MaxValue = current.GetComponent<IBossClass>().getHP();
        //audio = GetComponent<AudioSource>();
        //if (gameController == null)
        //    gameController = GameObject.Find("GameController");
        //print("CAZZO");
    }

    void Init(int child)
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(child).gameObject.SetActive(true);
        current = transform.GetChild(child).gameObject;
        if (gameController == null)
            gameController = GameObject.Find("GameController");
        gameController.GetComponent<GameController>().bossType = child;
        current.SendMessage("Init");
        currentClass = Classes.Square;
        if(healthBar == null)
        {
            healthBar = GameObject.Find("HealthBarMask").GetComponent<HealthBarScript>(); 
        }
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
        audio.clip = hitClips[Random.Range(0, 3)];
        audio.Play();
        //current.SendMessage("Damage");
       
    }


    public void PyramidDeath()
    {
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(0).gameObject.SetActive(false);
        current = transform.GetChild(1).gameObject;
        current.SendMessage("Init");
        current.transform.position = new Vector3(0, current.transform.position.y, 0);
        if (gameController == null)
            gameController = GameObject.Find("GameController");
        gameController.GetComponent<GameController>().bossType = 1;
        if (healthBar == null)
            healthBar = GameObject.Find("HealthBarMask").GetComponent<HealthBarScript>();
        healthBar.MaxValue = current.GetComponent<IBossClass>().getHP();
        currentClass = Classes.Triangle;
    }

    public void OctahedronDeath()
    {
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
        current = transform.GetChild(2).gameObject;
        if (gameController == null)
            gameController = GameObject.Find("GameController");
        gameController.GetComponent<GameController>().bossType = 2;
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
