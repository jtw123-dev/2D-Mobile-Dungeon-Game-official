using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IDamageable
{
    private Rigidbody2D _body;
    [SerializeField]private float _jumpForce=10;
    [SerializeField] private float _speed;
    private PlayerAnimation _playerAnim;
    private SpriteRenderer _renderer;
    private SpriteRenderer _swordRenderer;
    private Vector3 _swordPos;
    private Animator _anim;
    private bool _grounded=false;
    private bool _resetJump;
    [SerializeField]private LayerMask _groundLayer;

    public int Health { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _anim = GameObject.Find("Sprite").GetComponent<Animator>();
        _body = GetComponent<Rigidbody2D>();
        _swordRenderer = GameObject.Find("Sword_arc").GetComponent<SpriteRenderer>();
        _playerAnim = GameObject.Find("Player").GetComponentInChildren<PlayerAnimation>();
        _renderer = GameObject.Find("Player").GetComponentInChildren<SpriteRenderer>(); //flip it just like sword
        _swordPos = GameObject.Find("Sword_arc").transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        Movement();

        if (IsGrounded() == true && Input.GetMouseButtonDown(0))
        {
            _playerAnim.Attack();
        }
    }

    private void FixedUpdate()
    {
        IsGrounded();
    }   
    private void Movement()
    {
        float _horizontalInput = Input.GetAxisRaw("Horizontal");
        _grounded = IsGrounded();

        _playerAnim.Move(_horizontalInput);
        if (_horizontalInput>0)
        {
            _swordRenderer.flipX = false;
            _swordRenderer.flipY = false;
            _swordRenderer.transform.localPosition = new Vector3(1, 0.09f, 0.25f);
            _renderer.flipX = false;
        }
        else if (_horizontalInput<0)
        {
            _swordRenderer.flipX = true;
            _swordRenderer.flipY = true;
            _swordRenderer.transform.localPosition = new Vector3(-1, -0.09f, 0.25f);
            _renderer.flipX = true;
        }
        if (IsGrounded() == true && Input.GetKeyDown(KeyCode.Space))
        {
            _body.velocity = new Vector2(_body.velocity.x, _jumpForce);
            StartCoroutine("ResetJumpRoutine");
            _playerAnim.Jump(true);
        }
        _body.velocity = new Vector2(_horizontalInput * _speed, _body.velocity.y );     
    }
    bool IsGrounded()
    {
        float rayLength = 0.7f;
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,Vector2.down,rayLength,_groundLayer.value);
        Debug.DrawRay(transform.position, Vector2.down, Color.white);
        
        if (hitInfo.collider!=null)
        {
            if (_resetJump==false)
            
                _playerAnim.Jump(false);
                return true;              
            }
         
            return false;      
    }
    private IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.7f);
        _resetJump = false;
    }

    public void Damage()
    {
        Debug.Log("Player: Damage()");
    }
}
