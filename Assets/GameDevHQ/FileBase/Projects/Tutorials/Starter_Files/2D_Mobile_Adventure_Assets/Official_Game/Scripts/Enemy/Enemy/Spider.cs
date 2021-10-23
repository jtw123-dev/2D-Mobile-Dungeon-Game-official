using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy,IDamageable
{
    public int Health { get; set; }

    [SerializeField] private GameObject _acidPrefab;

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    public void Damage()
    {
        if (isDead==true)
        {
            return;
        }
        Health--;
        
        if (Health<1)
        {
            isDead = true;
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity);
            diamond.GetComponent<Diamond>().gems = base.gems;
            anim.SetTrigger("Death");
        }
    }
    public override void Update()
    {
        
    }

    public override void Movement()
    {
        //sit
    }

    public void Attack()
    {
        Instantiate(_acidPrefab, transform.position, Quaternion.identity);
    }
}
