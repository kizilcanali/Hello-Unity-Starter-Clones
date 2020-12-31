﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    //handle to the spider 
    private Spider _spider;
    private void Start()
    {
        //assign handle to the spider
        _spider = transform.parent.GetComponent<Spider>();
    }
    public void Fire()
    {
        //tell spider to fire
        Debug.Log("spdier fire");
        //use handle to call attack method
        _spider.Attack();
    }

}
