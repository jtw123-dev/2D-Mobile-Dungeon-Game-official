using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _body;
    [SerializeField]private float _jumpForce=10;
    [SerializeField] private float _speed;
    private PlayerAnimation _anim;
    private SpriteRenderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _anim = GameObject.Find("Sprite").GetComponent<PlayerAnimation>();
        _renderer = GameObject.Find("Sprite").GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void FixedUpdate()
    {
        IsGrounded();
    }   
    private void Movement()
    {
        float _horizontalInput = Input.GetAxisRaw("Horizontal");
        
        _anim.Move(_horizontalInput);
        if (_horizontalInput>0)
        {
            _renderer.flipX = false;
        }
        else if (_horizontalInput<0)
        {
            _renderer.flipX = true;
        }
        if (IsGrounded() == true && Input.GetKeyDown(KeyCode.Space))
        {
            _body.velocity = new Vector2(_body.velocity.x, _jumpForce);
        }
        _body.velocity = new Vector2(_horizontalInput * _speed, _body.velocity.y );     
    }
    bool IsGrounded()
    {
        float rayLength = 0.7f;
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,Vector2.down,rayLength);

        if (hitInfo.collider!=null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
