using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    public static HealthPlayer Instance { get; private set;}
    [SerializeField] public float _currentHealthPlayer = 100f;
    [SerializeField] private float _maxCurrentHealthPlayer = 100f;
    public TextMeshProUGUI TextHp;
    public Pause pause;
    public GameObject PanelGameOver;
    public UnityEngine.UI.Image image;
    private Animator animator;
    private BoxCollider2D collider2d;
    private Rigidbody2D rigidbody2;
    public bool isTakeHit = false;
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
        TextHp.text = _currentHealthPlayer.ToString()+ "/" +_maxCurrentHealthPlayer.ToString();
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
        StartCoroutine(StopMoveOnDamage());
        _currentHealthPlayer -= damage;
        image.fillAmount = _currentHealthPlayer/_maxCurrentHealthPlayer;
    }
    IEnumerator StopMoveOnDamage()
    {
        Physics2D.IgnoreLayerCollision(6,8,true);
        PlayerScr.Instance._moveSpeed = 0;
        isTakeHit = true;
        animator.SetBool("isTakeHit",true);
        yield return new WaitForSeconds(0.3f);
        isTakeHit = false;
        animator.SetBool("isTakeHit",false);
        PlayerScr.Instance._moveSpeed = 5;
        Physics2D.IgnoreLayerCollision(6,8,false);
    }
    IEnumerator IsDead()
    {
        PlayerScr playerScr = gameObject.GetComponent<PlayerScr>();
        playerScr.enabled = false;
        pause.enabled = false;
        rigidbody2.bodyType = RigidbodyType2D.Static;
        collider2d.enabled = false;
        animator.SetTrigger("IsDead");
        PanelGameOver.SetActive(true);
        yield return new WaitForSeconds(1f);
    }
    
}
