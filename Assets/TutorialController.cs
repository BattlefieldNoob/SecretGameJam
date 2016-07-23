using UnityEngine;
using System.Collections;

public class TutorialController : MonoBehaviour {

    enum States { CONTROLS, HOOKER, SHOOT , BOSS, END}

    public BossAi boss;

    States current = States.CONTROLS;


    public bool aPressed = false;
    public bool dPressed = false;
    public bool hookerPressed = false;
    public bool shootPressed = false;

    GameObject[] panels;

    public GameObject bossLifeBar;

    public Hooker hookAttack;

    public Gun gunAttack;

    bool canProcessInputs = false;

    // Use this for initialization
    void Start () {
        panels = new GameObject[transform.childCount];
        for(int i = 0; i < panels.Length; i++)
        {
            panels[i] = transform.GetChild(i).gameObject;
        }
        Time.timeScale = 0;
        StartCoroutine(Tutorial());
        boss.gameObject.SetActive(false);
        hookAttack.canShoot = false;
        gunAttack.canShoot = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (canProcessInputs)
        {
            switch (current)
            {

                case States.CONTROLS://devo controllare se il giocatore ha premuto sia a che d
                    {
                        if (Input.GetKeyDown(KeyCode.A))
                        {
                            aPressed = true;
                        }
                        if (Input.GetKeyDown(KeyCode.D))
                        {
                            dPressed = true;
                        }
                        if (aPressed && dPressed)
                        {
                            //vado alla fase successiva
                            current = States.HOOKER;
                        }
                    }
                    break;
                case States.HOOKER:
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            hookerPressed = true;
                        }
                        if (hookerPressed)
                        {
                            current = States.SHOOT;

                        }
                    }
                    break;

                case States.SHOOT:
                    {
                        if (Input.GetMouseButtonDown(1))
                        {
                            shootPressed = true;
                        }
                        if (shootPressed)
                        {
                            current = States.BOSS;
                        }
                    }
                    break;
            }
        }
	}


    IEnumerator Tutorial()
    {
        while (current != States.BOSS)
        {
            switchTutorialMessages(current);
            yield return new WaitForSecondsRealtime(2f);
            DisableAllPanels();
            Time.timeScale = 1;
            States last = current;
            canProcessInputs = true;
            while (last == current)//finchè il giocatore non fa quello che c'è scritto aspetto 
            {
                yield return new WaitForFixedUpdate();
            }
            canProcessInputs = false;
            yield return new WaitForSeconds(4f);// delay
            Time.timeScale = 0;
        }
        switchTutorialMessages(current);
        //devo far uscire il boss, con quello che ne consegue
        boss.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(8f);// delay
        DisableAllPanels();
        bossLifeBar.SetActive(true);
        Time.timeScale = 1;
    }


    void switchTutorialMessages(States messageToShow)
    {
        DisableAllPanels();
        switch (messageToShow)
        {
            case States.CONTROLS://devo controllare se il giocatore ha premuto sia a che d
                {
                    panels[0].gameObject.SetActive(true);
                }
                break;
            case States.HOOKER:
                {
                    panels[1].gameObject.SetActive(true);
                    //abilito l'attacco hook
                    hookAttack.canShoot = true;
                    
                }
                break;
            case States.SHOOT:
                {
                    panels[2].gameObject.SetActive(true);
                    //abilito l'attacco shoot 
                    gunAttack.canShoot = true;
                }
                break;
            case States.BOSS:
                {
                    panels[3].gameObject.SetActive(true);
                }
                break;
        }
    }

    void DisableAllPanels()
    {
        
        for(int i = 0; i < panels.Length; i++)
        {
            panels[i].gameObject.SetActive(false);
        }
    }
}
