using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    public static HealthPlayer Instance { get; private set;}
    [SerializeField] private float _currentHealthPlayer = 100f;
    [SerializeField] private float _maxCurrentHealthPlayer = 100f;
    public UnityEngine.UI.Image image;
    private Animator animator;
    private void Awake() 
    {
        Instance = this;
        animator = GetComponent<Animator>();
        _currentHealthPlayer = _maxCurrentHealthPlayer;
        image.fillAmount = _currentHealthPlayer/_maxCurrentHealthPlayer;
    }
    void Update()
    {
        DeadPlayer();
    }
    private void DeadPlayer()
    {
        if(_currentHealthPlayer <= 0)
        {
            Destroy(gameObject);
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
        PlayerScr.Instance.boxCollider2D.enabled = false;
        PlayerScr.Instance.rb.gravityScale = 0;
        PlayerScr.Instance._moveSpeed = 0;
        yield return new WaitForSeconds(0.3f);
        PlayerScr.Instance._moveSpeed = 5;
        PlayerScr.Instance.boxCollider2D.enabled = true;
        PlayerScr.Instance.rb.gravityScale = 1;
    }
}
