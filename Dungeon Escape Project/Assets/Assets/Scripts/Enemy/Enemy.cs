﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform pointA, pointB;

    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;

    protected bool isStart = true;
    protected bool isHit = false;
    protected bool isDeath = false;

    [SerializeField]public GameObject diamondPrefab;

    // position player
    protected Player player;

    public virtual void init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Start()
    {
        init();
    }
    public virtual void Update()
    {
        if ((anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") || anim.GetCurrentAnimatorStateInfo(0).IsName("idle")) && anim.GetBool("InCombat") == false ||isDeath == true)  // Normalde böyle değilde ben başta isimleri farklı koyduğum için birleştirirken böyle bir şey yaptım normalde tek isim olması lazım.
        {
            return;
        };

        if(isDeath == false)
        {
            Movement();
        }
        
    }

    public virtual void Movement()
    {
        if (currentTarget == pointA.position)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            if (isStart == false)
            {
                anim.SetTrigger("Idle");
            }
            isStart = false;
        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            anim.SetTrigger("Idle");
        }


        if(isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }

        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);

        if (distance > 2.0f)
        {
            isHit = false;
            anim.SetBool("InCombat", false);

        }

        Vector3 direction = player.transform.localPosition - transform.localPosition;
        //Debug.Log("Side: " + direction.x);

        if (direction.x < 0 && anim.GetBool("InCombat") == true)
        {
            sprite.flipX = true;
        }
        else if (direction.x > 0 && anim.GetBool("InCombat") == true)
        {
            sprite.flipX = false;
        }

    }


}
