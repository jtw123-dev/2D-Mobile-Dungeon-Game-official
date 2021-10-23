using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public override void Movement()
    {
        base.Movement();    
    }
    public void Damage()
    {
        if (isDead==true)
        {
            return;
        }
        health--;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);

        if (health <= 0)
        {
            isDead = true;
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) ;
            diamond.GetComponent<Diamond>().gems = base.gems;
            anim.SetTrigger("Death");
        }  
}
}
