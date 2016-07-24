using UnityEngine;
using System.Collections;

public class FakeBossAi : MonoBehaviour {

    enum Classes { Square, Triangle };

    public enum States { Free, Frozen }

    Classes currentClass;
    public States currentState;
    GameObject current;

    public HealthBarScript healthBar;

    public delegate void endTutorial();

    public event endTutorial end;
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

    public void Damage()
    {
        current.SendMessage("Damage");
    }

    void Update()
    {
        healthBar.Value = current.GetComponent<IBossClass>().getHP();
    }

    public void PyramidDeath()
    {
        print("End Tutorial");
        end();
    }
}
