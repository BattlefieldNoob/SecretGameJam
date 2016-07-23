using UnityEngine;
using System.Collections;
using System;

public class TriangleBossClass : MonoBehaviour, IBossClass
{

    float attackCooldownCounter = 0;
    public float attackCooldown = 10f;
    GameObject player;
    public float speed;
    public float hp = 100;
    public bool enraged = false;
    float maximum;
    bool dead = false;
    bool sinking = false;
    public float sinkingSpeed = 10;
    public float risingSpeed = 7;
    bool rising = true; 


    public GameObject attaccoPunte;

    // Use this for initialization
    void Start()
    {
        print("waiting for cooldown");
        player = GameObject.Find("Player");
        maximum = hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (rising)
        {
            transform.Translate(new Vector3(0, 1, 0)  * risingSpeed);
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
            if (attackCooldownCounter <= 0)
            {
                Attack();
                attackCooldownCounter = attackCooldown;//reset cooldown counter
            }
        }
        else if(!rising)
        {
            GoDown();
        }
    }

    public void Attack()
    {
        print("Attacco con le punte");
        Instantiate(attaccoPunte, Vector3.zero, Quaternion.identity);
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
        speed *= 2f;
        attackCooldown = 5;
        GetComponentInChildren<SpriteRenderer>().color = Color.red;
    }

    void Death()
    {
        dead = true;
        GetComponent<Collider2D>().enabled = false;
        GetComponentInChildren<SpriteRenderer>().color = Color.black;
        Destroy(GameObject.Find("SpikeFactory(Clone)"));
        //GetComponentInParent<BossAi>().SendMessage("SwitchClass");
    }

    void GoDown()
    {
        if (!sinking)
        {
            transform.Translate(-transform.position.normalized * sinkingSpeed);
            if (Vector2.Distance(transform.position, Vector2.zero) <= 3)
            {
                GetComponentInParent<Rigidbody2D>().velocity = Vector2.zero; 
                sinking = true;   
            }
        }
        if (sinking)
        {
            transform.Translate(new Vector3(0, -1, 0) * sinkingSpeed);
        }
    }

    

    public float getHP()
    {
        return hp;
    }
}
