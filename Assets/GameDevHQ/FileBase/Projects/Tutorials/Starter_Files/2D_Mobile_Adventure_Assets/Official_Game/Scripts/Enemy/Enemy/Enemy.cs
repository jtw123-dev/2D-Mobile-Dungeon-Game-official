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
    protected bool isHit = false;
    protected Player player;
    [SerializeField]protected Transform enemyPosition;
    protected float distance;
    protected Transform playerTransform;
    protected Collider2D enemyCollider;
    protected bool isDead = false;
    [SerializeField] protected GameObject diamondPrefab;
    
    public virtual void Init()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Start()
    {      
        Init();       
    }

    private void OnEnable()
    {
        enemyCollider = GameObject.FindGameObjectWithTag("Ignore").GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(enemyCollider, GetComponent<Collider2D>());
    }
    public virtual void Update()
    {       
        distance = Vector3.Distance(playerTransform.transform.position, enemyPosition.transform.position);
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            if (distance > 2)
            {
                isHit = false;
                anim.SetBool("InCombat", false);
            }
            return;
        }  
        if (isDead==false)
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

        if (transform.position==pointA.position)
        {
            currentTarget = pointB.position;
            anim.SetTrigger("Idle");
        }                
        
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            anim.SetTrigger("Idle");
        }
        if (isHit==false)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }

        Vector3 directionSwitch = player.transform.localPosition - transform.localPosition;

        if (anim.GetBool("InCombat"))
        {
            if (directionSwitch.x > 0)
                sprite.flipX = false;

            else if (directionSwitch.x < 0)
            {
                sprite.flipX = true;
            }
        }
    }
}
