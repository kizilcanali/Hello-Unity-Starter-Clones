using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }
    public override void init()
    {
        base.init();
        Health = base.health;
    }
    public override void Movement()
    {
        base.Movement();
    }

    public void Damage()
    {

        if (isDeath == true)
            return;

        Debug.Log("Skeleton damage!");
        Health--;
        
        anim.SetTrigger("Hit");

        isHit = true;
        anim.SetBool("InCombat", true);
        
        if(Health < 1)
        {
            isDeath = true;
            anim.SetTrigger("Death");
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().valueOfDiamond = base.gems;
        }
    }
}
