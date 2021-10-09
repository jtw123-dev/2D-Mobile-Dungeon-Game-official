using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{   
    [SerializeField]protected int health;
    [SerializeField]protected int speed = 5;
    [SerializeField]protected int gems;
    [SerializeField]protected Transform pointA, pointB;
    [SerializeField]protected bool flip;

    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        Init();       
    }
    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }
        Movement();
    }
    public virtual void Movement()
    {
        if (transform.position == pointA.position)
        {
            if (sprite.flipX == true)
            {
                sprite.flipX = false;
            }
            anim.SetTrigger("Idle");
            currentTarget = pointB.position;
        }
        else if (transform.position == pointB.position)
        {
            anim.SetTrigger("Idle");
            sprite.flipX = true;
            currentTarget = pointA.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }
}
