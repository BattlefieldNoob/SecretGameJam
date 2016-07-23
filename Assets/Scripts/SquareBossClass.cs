using UnityEngine;
using System.Collections;
using System;

public class SquareBossClass : MonoBehaviour, IBossClass
{

    float attackCooldownCounter = 5f;
    public float attackCooldown = 10f;

    float wallCooldownCounter = 5f;
    bool rising = true;
    public float risingSpeed;
    GameObject player;
    bool dead;
    bool enraged;
    bool sinking;
    public float speed;

    public float attackHeightInstantiation;

    public GameObject attaccoCubi;
    public GameObject cubiDifesa;
    bool stopped;
    public float sinkingSpeed;
    public float hp = 100;
    public float maximum;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        maximum = hp;
    }

    // Update is called once per frame
    void Update()
    {


        if (rising)
        {
            transform.Translate(new Vector3(0, 1, 0) * risingSpeed);
            GameObject.FindGameObjectWithTag("MainCamera").SendMessage("StartShaking");
            if (Vector2.Distance(Vector2.zero, transform.position) < 3)
            {
                rising = false;
                GetComponent<Collider2D>().enabled = true;
            }

        }

        if (!dead && !rising)
        {
            GetComponentInParent<Rigidbody2D>().AddForce((player.transform.position - transform.position).normalized * speed);
            attackCooldownCounter -= Time.deltaTime;
            wallCooldownCounter -= Time.deltaTime;
            if (attackCooldownCounter <= 0)
            {
                Attack();
                attackCooldownCounter = attackCooldown; //reset cooldown counter
            }

        }
        else if (!rising)
        {
            GoDown();
        }


    }

    public void Attack()
    {
        print("Attacco con le punte");
        Instantiate(attaccoCubi, new Vector2(0, attackHeightInstantiation), Quaternion.identity);
    }

    public void MakeWallLikeTrump()
    {
        if (!GameObject.Find("CubeWallFactory"))//se non esiste nessun pezzo di muro 
        {
            print("MAKE AMERICA GREAT AGAIN!");

            Instantiate(cubiDifesa, transform.position, Quaternion.identity);

        }
    }

    public void Damage()
    {
        hp--;
        if (hp == 0)
        {
            Death();
        }

        if (hp <= maximum * 0.35f && !enraged)
            Enrage();

    }

    void Enrage()
    {
        print("ENRAGED!!!!");
        enraged = true;
        MakeWallLikeTrump();
        attackCooldown = 5;

    }

    void Death()
    {
        dead = true;
        GetComponent<Collider2D>().enabled = false;
        GetComponentInChildren<SpriteRenderer>().color = Color.black;
        Destroy(GameObject.Find("Shield(Clone)"));
        Destroy(GameObject.Find("SquareRainFactory(Clone)"));
        player.GetComponent<PlayerLife>().hp = player.GetComponent<PlayerLife>().maxHP;


    }

    void GoDown()
    {
        if (!sinking)
        {
            GetComponentInParent<Rigidbody2D>().velocity = Vector2.zero;
            StartCoroutine(WaitAndSink());
        }
        if (sinking && !stopped)
        {
            transform.Translate(new Vector3(0, -1, 0) * sinkingSpeed);
            //transform.position = new Vector3( transform.position.x +  Mathf.Sin(Time.time * speed),transform.position.y,transform.position.z);
            //if (Vector2.Distance(transform.position, GameObject.Find("Paperella").transform.position) < 10)
            if (transform.position.y <= GameObject.Find("Paperella").transform.position.y)
            {
                stopped = true;
                GetComponentInParent<BossAi>().SendMessage("CubeDeath");
            }
        }
    }

    IEnumerator WaitAndSink()
    {

        yield return new WaitForSeconds(1.5f);
        sinking = true;
    }

    public float getHP()
    {
        return hp;
    }
}
