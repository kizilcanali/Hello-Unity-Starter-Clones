using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    //handle animator
    private Animator _anim;
    private Animator _SwordAnim;
    void Start()
    {
        //assign handle to animator
        _anim = GetComponentInChildren<Animator>();
        _SwordAnim = transform.GetChild(1).GetComponentInChildren<Animator>(); //2.Elemanın animatoruna ulaşmak için.
    }

    public void Move(float move)
    {
        _anim.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool IsJump)
    {
        _anim.SetBool("Jumping", IsJump);
    }
    
    public void Attack()
    {
        _anim.SetTrigger("Attack");
        _SwordAnim.SetTrigger("SwordAnimation");
    }

    public void Death()
    {
        _anim.SetTrigger("Death");
    }
}
