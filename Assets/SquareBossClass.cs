using UnityEngine;
using System.Collections;
using System;

public class SquareBossClass : MonoBehaviour,IBossClass {

    float attackCooldownCounter = 0;
    public float attackCooldown = 10f;

    public float attackHeightInstantiation;

    public GameObject attaccoCubi;
    public GameObject cubiDifesa;

    // Use this for initialization
    void Start()
    {
        print("waiting for cooldown");
    }

    // Update is called once per frame
    void Update()
    {
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
        Instantiate(attaccoCubi, new Vector2(0,attackHeightInstantiation), Quaternion.identity);
        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        if (boss.GetComponent<BossAi>().currentState != BossAi.States.Frozen)
        {
            boss.GetComponent<BossAi>().currentState = BossAi.States.Frozen;
            Instantiate(cubiDifesa, boss.transform.position, Quaternion.identity);
        }
    }
}
