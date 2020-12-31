using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health { get; set; }
    public GameObject acidEffectPrefab;
    //use for initialization
    public override void init()
    {
        base.init();
        Health = base.health;
    }
    public override void Update()
    {
        
    }
    public override void Movement()
    {
        
    }

    public void Damage()
    {
        if (isDeath == true)
            return;

        Debug.Log("Spider damage!");
        Health--;

        anim.SetTrigger("Hit");

        isHit = true;
        anim.SetBool("InCombat", true);

        if (Health < 1)
        {
            isDeath = true;
            anim.SetTrigger("Death");
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().valueOfDiamond = base.gems;

        }
    }

    public void Attack()
    {
        //instantiate the acid effect
        Instantiate(acidEffectPrefab, transform.position, Quaternion.identity);
    }
}
