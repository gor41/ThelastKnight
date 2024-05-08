using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    public static HealthPlayer Instance { get; private set;}
    [SerializeField] public float _currentHealthPlayer = 100f;
    [SerializeField] private float _maxCurrentHealthPlayer = 100f;
    public UnityEngine.UI.Image image;
    private Animator animator;
    private BoxCollider2D collider2d;
    private Rigidbody2D rigidbody2;
    private void Awake() 
    {
        Instance = this;
        animator = GetComponent<Animator>();
        _currentHealthPlayer = _maxCurrentHealthPlayer;
        image.fillAmount = _currentHealthPlayer/_maxCurrentHealthPlayer;
        collider2d = GetComponent<BoxCollider2D>();
        rigidbody2 = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        DeadPlayer();
        image.fillAmount = _currentHealthPlayer/_maxCurrentHealthPlayer;
    }
    private void DeadPlayer()
    {
        if(_currentHealthPlayer <= 0)
        {
           StartCoroutine(IsDead());
            
            
        }
    }
    public void TakeHit(int damage)
    {
        animator.Play("HeroKnight_Hurt");
        StartCoroutine(StopMoveOnDamage());
        _currentHealthPlayer -= damage;
        image.fillAmount = _currentHealthPlayer/_maxCurrentHealthPlayer;
    }
    IEnumerator StopMoveOnDamage()
    {
        Physics2D.IgnoreLayerCollision(6,8,true);
        PlayerScr.Instance.rb.gravityScale = 0;
        PlayerScr.Instance._moveSpeed = 0;
        yield return new WaitForSeconds(0.3f);
        PlayerScr.Instance._moveSpeed = 5;
        Physics2D.IgnoreLayerCollision(6,8,false);
        PlayerScr.Instance.rb.gravityScale = 1;
    }
    IEnumerator IsDead()
    {
        PlayerScr playerScr = gameObject.GetComponent<PlayerScr>();
        playerScr.enabled = false;
        rigidbody2.bodyType = RigidbodyType2D.Static;
        collider2d.enabled = false;
        animator.SetTrigger("IsDead");
        yield return new WaitForSeconds(1f);
    }
    
}
