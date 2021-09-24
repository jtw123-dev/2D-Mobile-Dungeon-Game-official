using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _body;
    [SerializeField]private float _jumpForece;
    private bool _isGrounder;

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float _horizontalInput = Input.GetAxisRaw("Horizontal");
        _body.velocity =new Vector2(_horizontalInput,_body.velocity.y);
    }
    
}
