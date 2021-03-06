﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour
{

    GameObject current;

    int currentIndex = -1;
    int nextState = 0;
    public GameObject[] forms;
    public float speed;
    public PlayerLife healthStatus;



    // Use this for initialization
    void Start()
    {
        current = forms[0];
        current.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(Input.GetAxis("Horizontal"), 0) * speed);

            if (healthStatus.damaged)
                ShowDamages();
            else
            {
                SpriteRenderer spRend = current.GetComponent<SpriteRenderer>();
                Color col = spRend.color;
                col.a = 1f;
                spRend.color = col;
            }



            //triangle
            if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire2"))
            {
                if (current.name != "Triangle")
                {
                    SwitchState();
                }
            }

            if (Input.GetMouseButtonDown(1) || Input.GetButtonDown("Fire3"))
            {
                if (current.name != "Circle")
                {
                    SwitchState();
                }
            }
        }
    }

    void ShowDamages()
    {

        SpriteRenderer spRend = current.GetComponent<SpriteRenderer>();

        Color col = spRend.color;
        if (col.a == 1)
            col.a = 0f;
        else
            col.a = 1f;
        spRend.color = col;
    }

    void SwitchState()
    {
        Destroy(GameObject.Find("Hook(Clone)"));
        currentIndex = nextState;
        //switch state 
        nextState = currentIndex + 1;
        print(nextState);
        if (nextState == forms.Length)
            nextState = 0;
        print("next Position:" + currentIndex);
        forms[currentIndex].SetActive(false);
        forms[nextState].SetActive(true);
        current = forms[nextState];
        print("switched state");
    }
}
