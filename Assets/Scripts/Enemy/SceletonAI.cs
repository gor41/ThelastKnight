using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceletonAI : MonoBehaviour
{
    [Header("Floats")]
    public float SceletSpeed;
    public float AttackRadiusScelet;

    [Header("GameObjects and other")]
    public LayerMask PlayerIsLayer;
    public GameObject AttackBoxScelet;
    public Transform Startpoint;
    public Transform AttakcRadiusPointScelet;
    

    private Animator animator;
    private Transform player;


    private bool isFlipped = false;
    private bool isCanAttack = false;
    private bool isAttack = false;
    public bool isKdAttack = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        LookToPlayer();
        MoveScelet();
        AttackScelet();
    }
    public void LookToPlayer()
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
    public void MoveScelet()
    {
        Vector2 targetPlayer = new Vector2(player.position.x, transform.position.y);
        Vector2 tarhetStartPoint = new Vector2(Startpoint.position.x, transform.position.y);
        if (Vector2.Distance(transform.position, player.position) < 5 && isAttack == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPlayer, SceletSpeed * Time.deltaTime);
            animator.SetBool("isRunScl", true);
        }
        else if(Vector2.Distance(transform.position,player.position) > 5 && isAttack == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, tarhetStartPoint, SceletSpeed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, tarhetStartPoint) > 0.1f && isAttack == false)
        {
            animator.SetBool("isRunScl", false);
        }
    }
    public void AttackScelet()
    {
        isCanAttack = Physics2D.OverlapCircle(AttakcRadiusPointScelet.position, AttackRadiusScelet, PlayerIsLayer);
        if(isCanAttack == true && isAttack == false && isKdAttack == false)
        {
            StartCoroutine(AttackSceletCoroutine());
            StartCoroutine(KDAttack());
            animator.SetBool("isAttackScl", true);
        }
        else
        {
            animator.SetBool("isAttackScl", false);
        }




    }
    IEnumerator AttackSceletCoroutine()
    {
        AttackBoxScelet.SetActive(true);
        isAttack = true;
        yield return new WaitForSeconds(0.2f);
        AttackBoxScelet.SetActive(false);
        isAttack = false;
    }
    IEnumerator KDAttack()
    {
        isKdAttack = true;
        yield return new WaitForSeconds(0.5f);
        isKdAttack = false;

    }

}
