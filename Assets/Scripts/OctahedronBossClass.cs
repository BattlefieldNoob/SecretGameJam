﻿using UnityEngine;
using System.Collections;
using System;

public class OctahedronBossClass : MonoBehaviour, IBossClass {
    float attackCooldownCounter = 0;
    public float attackCooldown = 10f;
    GameObject player;
    public float speed;
    public float hp = 100;
    public bool enraged = false;
    float maximum;


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
        GetComponentInParent<BossAi>().SendMessage("SwitchClass");
    }

    public float getHP()
    {
        return hp;
    }
}
