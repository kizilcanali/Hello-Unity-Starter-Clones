using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour, IDamageable
{
    //get handle to rigidbody
    private Rigidbody2D _rb;
    [SerializeField]
    private float _jumpForce = 5;
    [SerializeField]
    private LayerMask _groundLayer;
    private bool _resetJump = false;
    [SerializeField]
    private float _speed = 2.0f;
    //handle to player animation
    private PlayerAnimation _playerAnim;
    private SpriteRenderer _playerSprite;
    private SpriteRenderer _swordArcSprite;

    //diamond amount
     public int hasAmountOfDiamonds = 0;

    
    private bool _grounded = false;

    public int Health { get; set; }

    void Start()
    {
        //assign handle of rigidbody
        _rb = GetComponent<Rigidbody2D>();

        //asssign handle to playeranimation
        _playerAnim = GetComponent<PlayerAnimation>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
        _swordArcSprite = transform.GetChild(1).GetComponentInChildren<SpriteRenderer>();
        Health = 4;
        
    }
    void Update()
    {
        Movement();
        Attack();
    }
    
    void Movement()
    {
        float move =CrossPlatformInputManager.GetAxis("Horizontal");  // will give L / R hem pc hem mobilde çalışır.

        _grounded = IsGrounded();

        if (move > 0)
        {
            Flip(true);
        }
        else if (move < 0)
        {
            Flip(false);
        };

        if ((CrossPlatformInputManager.GetButtonDown("B_Button") || Input.GetKeyDown(KeyCode.Space)) && IsGrounded() == true) //jump
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpRoutine());
            _playerAnim.Jump(true);
        }
        _rb.velocity = new Vector2(move * _speed, _rb.velocity.y);
        _playerAnim.Move(move);
    }
    void Attack()
    {
        if (CrossPlatformInputManager.GetButtonDown("A_Button") && IsGrounded() == true )
        {
            
            _playerAnim.Attack();
        }
    }
    void Flip(bool faceRight)
    {
        if (faceRight == true)
        {
            _playerSprite.flipX = false;
            _swordArcSprite.flipX = false;
            _swordArcSprite.flipY = false;

            Vector3 newPos = _swordArcSprite.transform.localPosition;
            newPos.x = 1.01f;
            _swordArcSprite.transform.localPosition = newPos;

        }
        else if (faceRight == false)
        {
            _playerSprite.flipX = true;
            _swordArcSprite.flipX = true;
            _swordArcSprite.flipY = true;

            Vector3 newPos = _swordArcSprite.transform.localPosition;
            newPos.x = -1.01f;
            _swordArcSprite.transform.localPosition = newPos;

        };

    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1<<8);
        if(hitInfo.collider != null)
        {
            if(_resetJump == false)
            {
                _playerAnim.Jump(false);
                return true;
            }
                
        }
            return false;
    }
    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

    public void Damage()
    {
        if(Health < 1)
        {
            return;
        }

        Health--;
        UIManager.Instance.UpdateLives(Health);
        if(Health < 1)
        {
            _playerAnim.Death();
        }
    }
    public void AddGems(int amount)
    {
        hasAmountOfDiamonds += amount;
        UIManager.Instance.UpdateGemCount(hasAmountOfDiamonds);
    }

}



