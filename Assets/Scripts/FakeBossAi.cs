using UnityEngine;
using System.Collections;

public class FakeBossAi : MonoBehaviour {


    enum Classes { Square, Triangle };

    public enum States { Free, Frozen }

    Classes currentClass;
    public States currentState;
    GameObject current;


    public HealthBarScript healthBar;
    // Use this for initialization
    void Start()
    {
        //StartCoroutine(AIMovementLoop());
        //attivo in modo scriptato la classe "Square"
        transform.GetChild(1).gameObject.SetActive(false);
        current = transform.GetChild(0).gameObject;
        currentClass = Classes.Square;
        healthBar.MaxValue = current.GetComponent<IBossClass>().getHP();
    }

    void Update()
    {
        healthBar.Value = current.GetComponent<IBossClass>().getHP();
    }

    public void ComeOut()
    {
        current.SendMessage("ComeOut");
    }

    public void Damage()
    {
        current.SendMessage("Damage");
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
}
