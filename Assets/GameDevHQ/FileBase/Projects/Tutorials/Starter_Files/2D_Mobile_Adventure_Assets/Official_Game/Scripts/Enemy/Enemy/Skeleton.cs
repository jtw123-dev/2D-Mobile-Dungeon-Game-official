using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy,IDamageable
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

        Vector3 directionSwitch = player.transform.localPosition - transform.localPosition;

        if ( anim.GetBool("InCombat"))
        {
            if ( directionSwitch.x > 0)
            sprite.flipX = false;

            else if (directionSwitch.x<0)
            {
                sprite.flipX = true;
            }
        }
       
    }
    public void Damage()
    {
        Debug.Log("Damage");
        health--;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);     
        
        if (health<=0)
        {
            Destroy(gameObject);
        }
    }
}
