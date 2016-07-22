using UnityEngine;
using System.Collections;
using System;

public class SquareBossClass : MonoBehaviour,IBossClass {

    float attackCooldownCounter = 5f;
    public float attackCooldown = 10f;

    float wallCooldownCounter = 5f;

    public float attackHeightInstantiation;

    public GameObject attaccoCubi;
    public GameObject cubiDifesa;

    // Use this for initialization
    void Start()
    {
        wallCooldownCounter = UnityEngine.Random.Range(15f, 25f);//counter random per il muro
    }

    // Update is called once per frame
    void Update()
    {
        attackCooldownCounter -= Time.deltaTime;
        wallCooldownCounter -= Time.deltaTime;
        if (attackCooldownCounter <= 0)
        {
            Attack();
            attackCooldownCounter = attackCooldown; //reset cooldown counter
        }
        if (wallCooldownCounter <= 0)
        {
            MakeWallLikeTrump();
            wallCooldownCounter = UnityEngine.Random.Range(15f, 25f); //reset cooldown counter
        }
    }

    public void Attack()
    {
        print("Attacco con le punte");
        Instantiate(attaccoCubi, new Vector2(0,attackHeightInstantiation), Quaternion.identity);       
    }

    public void MakeWallLikeTrump()
    {
        if (!GameObject.Find("CubeWallFactory"))//se non esiste nessun pezzo di muro 
        {
            print("MAKE AMERICA GREAT AGAIN!");
            GameObject boss = GameObject.FindGameObjectWithTag("Boss");
            if (boss.GetComponent<BossAi>().currentState != BossAi.States.Frozen)
            {
                boss.GetComponent<BossAi>().currentState = BossAi.States.Frozen;
                Instantiate(cubiDifesa, boss.transform.position, Quaternion.identity);
            }
        }
    }
}
