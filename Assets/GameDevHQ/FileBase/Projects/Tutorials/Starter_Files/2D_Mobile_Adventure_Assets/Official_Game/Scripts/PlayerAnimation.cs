using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private Animator _swordAnim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _swordAnim = GameObject.Find("Sword_arc").GetComponent<Animator>();
    }
    public void Move(float move)
    {
        _anim.SetFloat("Move", Mathf.Abs (move));
    }
    public void Jump(bool jumping)
    {
        _anim.SetBool("Jumping", jumping);
    }  

    public void Attack ()
    {
        _anim.SetTrigger("Attack");
        _swordAnim.SetTrigger("SwordAnimation");
    }
}
