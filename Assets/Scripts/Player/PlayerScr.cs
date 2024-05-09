using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class PlayerScr : MonoBehaviour
{
    public static PlayerScr Instance { get;private set;}

    [Header("Controller Settings")]
    public float _moveSpeed;
    public float _jumpForce;
    public Transform feetPos;
    public LayerMask WhatIsGrounded;
    public float CheckRadius;
    private float _moveInput;
    public GameObject AttackHitBox;
    private bool isGrounded = false;
    private bool isAttacked = false;
    private bool isAttackAndNoRoll = false;
    private bool faceRight = true;
    private bool LockPos=false;  
    [Header("Dash Settings")]
    public bool isRoll = false;
    public bool CanRoll = true;
    public float _rollPower; 
    public float _rollTime;
    public float _rollKD;
    [Header("Audio Setting")]
    public AudioClip[] audioClips;
    public AudioSource audioSource;

    public Rigidbody2D rb;
    private Animator animator;
    public BoxCollider2D boxCollider2D;
    private void Awake() 
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        Jump();
        OnAttack();
        Roll();
    }
    private void FixedUpdate() 
    {
        Movement();
    }
    private void Movement()
    {
        if(isRoll == false && LockPos == false)
        {
        _moveInput = Input.GetAxis("Horizontal"); 
        rb.velocity = new Vector2(_moveInput * _moveSpeed,rb.velocity.y);
        }
        if(faceRight == false && _moveInput > 0)
        {
            Flip();
        }
        if(faceRight == true && _moveInput < 0)
        {
            Flip();
        }

        
        if(_moveInput == 0 && isRoll == false)
        {
            animator.SetBool("isRun",false);
        }
        else
        {
            animator.SetBool("isRun",true);
        }
    }
    private void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, CheckRadius,WhatIsGrounded);

        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space) && isRoll == false)
        {
            rb.velocity = Vector3.up * _jumpForce;
        }


        if(isGrounded == false  && isRoll == false)
        {
            animator.SetBool("isJump",true);
        }
        else
        {
            animator.SetBool("isJump",false);
        }
    }
    private void OnAttack()
    {
        if(Input.GetMouseButtonDown(0) && isAttacked == false && isGrounded == true && isRoll == false && HealthPlayer.Instance.isTakeHit == false)
        {
           animator.SetBool("isAttack",true);
           StartCoroutine(DoAttack()); 
           StartCoroutine(KDAttack()); 
           StartCoroutine(StopPos());
        } 
        else
        {
            animator.SetBool("isAttack",false); 
             
        }  
    }
    private void Roll()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && isGrounded == true && CanRoll == true && HealthPlayer.Instance.isTakeHit == false && isAttackAndNoRoll == false)
        {
            StartCoroutine(DoRoll());
            animator.SetBool("isRoll", true);
                 
        }
        else
        {
            animator.SetBool("isRoll", false);
            
        }

    }
    private void Flip()
    {
        faceRight =!faceRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    public void AudioRunOn()
    {
        audioSource.PlayOneShot(audioClips[0]);
    }
    public void AudioAttack()
    {
        audioSource.PlayOneShot(audioClips[1]);
    }
    public void AudioJump()
    {
        audioSource.PlayOneShot(audioClips[2]);
    }

    IEnumerator DoAttack()
    {
        AttackHitBox.SetActive(true);
        isAttackAndNoRoll = true;
        CanRoll = false;
        yield return new WaitForSeconds(0.25f);
        CanRoll = true;
        isAttackAndNoRoll = false;
        AttackHitBox.SetActive(false);
        
    }
    IEnumerator KDAttack()
    {
        isAttacked = true;
        yield return new WaitForSeconds(0.5f);
        isAttacked = false;

    }
    IEnumerator StopPos()
    {
        _moveSpeed = 0;
        LockPos = true;
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(0.3f);
        _moveSpeed = 5;
        LockPos = false;
    }
    IEnumerator DoRoll()
    {
        Physics2D.IgnoreLayerCollision(6,8,true);
        isRoll = true;
        CanRoll = false;
        rb.velocity = new Vector2(transform.localScale.x *_rollPower, 0);
        yield return new WaitForSeconds(_rollTime);
        isRoll = false;
        Physics2D.IgnoreLayerCollision(6,8,false);
        yield return new WaitForSeconds(_rollKD);
        CanRoll = true;
    }
}
