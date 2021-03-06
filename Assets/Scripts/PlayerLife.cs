﻿using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour
{

    public float hp = 30;
    public bool damaged = false;
    float counter = 0;
    public float maxHP; 
    public float invincibilityTime = 2.5f;
    public HealthBarScript playerHealth;
    public GameObject gameOver; 

    // Use this for initialization
    void Start()
    {
        if (playerHealth == null)
        {
            playerHealth = GameObject.Find("PlayerHealthBar").GetComponent<HealthBarScript>();
        }
        playerHealth.MaxValue = hp;
        maxHP = hp; 
    }

    // Update is called once per frame
    void Update()
    {
        
        if (damaged)
        {

            counter += Time.deltaTime;
            if (counter >= invincibilityTime)
                damaged = false;
        }

        if(!damaged)
            counter = 0;
        playerHealth.Value = hp;
    }

    void Damage()
    {
        GetComponent<AudioSource>().Play(); 
        damaged = true; 
        hp--;
        if (hp <= 0)
            Death(); 

    }

    void Death()
    {
        playerHealth.Value = hp;
        GameObject.Find("GameController").SendMessage("GameOver");
        Destroy(gameObject);
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Boss" || coll.gameObject.tag == "Pikes")
            if (!damaged)
                Damage();
    }
}
