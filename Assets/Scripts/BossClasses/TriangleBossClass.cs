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


    public GameObject attaccoPunte;

    // Use this for initialization
    void Start()
    {
        print("waiting for cooldown");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponentInParent<Rigidbody2D>().AddForce((player.transform.position - transform.position).normalized * speed);
        attackCooldownCounter -= Time.deltaTime;
        if (attackCooldownCounter <= 0)
        {
            Attack();
            attackCooldownCounter = attackCooldown;//reset cooldown counter
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
    }

    void Death()
    {
        GetComponentInParent<BossAi>().SendMessage("SwitchClass");
    }

    public float getHP()
    {
        return hp;
    }
}
