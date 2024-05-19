using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SceletonAI : MonoBehaviour
{
    [Header("Floats")]
    public float SceletSpeed;
    public float AttackRadiusScelet;
    public float CheckRadiusScl;

    [Header("GameObjects and other")]
    public LayerMask PlayerIsLayer;
    public LayerMask WhatisGroundScl;
    public GameObject AttackBoxScelet;
    public GameObject DaedScl;
    public Transform Startpoint;
    public Transform feetPosScl;
    public Transform AttakcRadiusPointScelet;
    private Rigidbody2D rb;
    private EnemHealthScr enemHealthScr;
    

    private Animator animator;
    private Transform player;


    private bool isFlipped = false;
    private bool isCanAttack = false;
    private bool isAttack = false;
    private bool isKdAttack = false;
    private bool isWalkToPlayer = false;
    private bool isWalkToStartPonit = false;
    public bool isChill = false;
    private bool isGroundedScl = false;

    private void Awake()
    {
        enemHealthScr = GetComponent<EnemHealthScr>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        WalkToPlayer();
        WalkToStartPoint();
        AttackScelet();
        isGroundCheck();
        CheckGroundForward();
    }
    public void isGroundCheck()
    {
        isGroundedScl = Physics2D.OverlapCircle(feetPosScl.position,CheckRadiusScl,WhatisGroundScl);
        if(isGroundedScl == false)
        {
            animator.SetBool("isRunScl", false);
        }
    }
    public void WalkToPlayer()
    {
        Vector2 targetPlayer = new Vector2(player.position.x, transform.position.y);
        if (Vector2.Distance(transform.position, player.position) < 4  && isAttack == false && isGroundedScl == true && isChill == false) 
        { 
            transform.position = Vector2.MoveTowards(transform.position, targetPlayer, SceletSpeed * Time.deltaTime);
            animator.SetBool("isRunScl", true);
            isWalkToPlayer = true;
            isWalkToStartPonit = false;
        }
        if(isWalkToPlayer == true  && isAttack == false)
        {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
        }
    }
    public void WalkToStartPoint()
    {
        Vector2 tarhetStartPoint = new Vector2(Startpoint.position.x, transform.position.y);
        if(Vector2.Distance(transform.position,player.position) > 4 && isAttack == false && isGroundedScl == true || isChill == true)
        {
            animator.SetBool("isRunScl", true);
            transform.position = Vector2.MoveTowards(transform.position, tarhetStartPoint, SceletSpeed * Time.deltaTime);
            isWalkToPlayer = false;
            isWalkToStartPonit = true;
        }
        if(isWalkToStartPonit == true && isAttack == false)
        {
        Vector3 flippedToStartPoint = transform.localScale;
        flippedToStartPoint.z *= -1f;
        if (transform.position.x > tarhetStartPoint.x && isFlipped)
        {
            transform.localScale = flippedToStartPoint;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < tarhetStartPoint.x && !isFlipped)
        {
            transform.localScale = flippedToStartPoint;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
        }
        if(Vector2.Distance(transform.position,tarhetStartPoint)< 0.1f)
        {
            animator.SetBool("isRunScl", false);
            isChill = false;
        }
    }
    public void CheckGroundForward()
    {
         RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position,transform.right * -1,0.5f,LayerMask.GetMask("Ground"));
        if(raycastHit2D.collider != null)
        {
            isChill = true;
        }
    }
    public void AttackScelet()
    {
        isCanAttack = Physics2D.OverlapCircle(AttakcRadiusPointScelet.position, AttackRadiusScelet, PlayerIsLayer);
        if(isCanAttack == true && isAttack == false && isKdAttack == false)
        {
            StartCoroutine(AttackSceletCoroutine());
            StartCoroutine(KDAttack());
        }
    }
    IEnumerator AttackSceletCoroutine()
    {
        isAttack = true;
        animator.SetBool("isAttackScl", true);
        yield return new WaitForSeconds(0.2f);
        AttackBoxScelet.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        AttackBoxScelet.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        isAttack = false;
        animator.SetBool("isAttackScl",false);
    }
    IEnumerator KDAttack()
    {
        isKdAttack = true;
        yield return new WaitForSeconds(1f);
        isKdAttack = false;
    }
    IEnumerator StartDeadScl()
    {
        Instantiate(DaedScl,transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0);
    }
}
