using System.Collections;
using UnityEngine;
public class BossScr : MonoBehaviour
{
    [Header("Objects")]
    public Transform player;
    public Transform attackPoint;
    public LayerMask WhatIsPlayer;
    public GameObject SpellPrefab;
    public GameObject AttackBoxBoss;

    [Header("Variables")]
    public float attackRadius;
    public float speedBoss = 1f;
    public float KDSpell = 0f;

    [Header("AudioSource")]
    public AudioClip[] audioClips;
    public AudioSource Audioisource;
    

    
    
    private Rigidbody2D rb;
    private Animator animator;
    private bool IsCanAtackBoss = false;
    private bool isFlipped = false;
    private bool isAttsckBoss = true;
    private bool isCastSpell = false;
    private bool isWalkToPlayr = true;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update() 
    {
        AttackBoss();
        LookAtPlayer();
        CastSpell();
    }
    void FixedUpdate()
    {
        WalkToPlayer();  
    }
    public void WalkToPlayer()
    {
        if (isWalkToPlayr == true && isCastSpell == false )
        {
        Vector2 target = new Vector2(player.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, target, speedBoss * Time.fixedDeltaTime); 
        animator.SetBool("IsWalkBoss",true);   
        }
    }
    public void AttackBoss()
    {
        IsCanAtackBoss = Physics2D.OverlapCircle(attackPoint.position,attackRadius,WhatIsPlayer);
        if(isAttsckBoss == true && IsCanAtackBoss == true && isCastSpell == false)
        {
            StartCoroutine(Attack());
            StartCoroutine(StopMoveDuringAttack());
            animator.SetBool("IsAttackBoss",true);
        }
        else
        {
            animator.SetBool("IsAttackBoss",false);
        }
        // Invoke("SpawnSpell",4);
    }
    public void SpawnSpell()
    {
        Instantiate(SpellPrefab,new Vector3(player.position.x,-2f,1f),Quaternion.identity);

    }
    public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFlipped )
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
    public void CastSpell()
    {
        KDSpell += Time.deltaTime;
        if (KDSpell >= 10f)
        {
            KDSpell = 0f;
            StartCoroutine(CastSpellIenumerator());
        }
        
    }
    IEnumerator Attack()
    {
        isAttsckBoss = false;
        yield return new WaitForSeconds(0.25f);
        AttackBoxBoss.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        AttackBoxBoss.SetActive(false);
        yield return new WaitForSeconds(1f);
        isAttsckBoss = true;
    }
    IEnumerator SpellAttack()
    {
        yield return new WaitForSeconds(3);
        SpawnSpell();  
    }
    IEnumerator CastSpellIenumerator()
    {
        animator.SetBool("IsCastSpell",true);
        isWalkToPlayr = false;
        isCastSpell = true;
        StartCoroutine(SpellAttack());
        yield return new WaitForSeconds(3f);
        isCastSpell = false;
        isWalkToPlayr = true;
        animator.SetBool("IsCastSpell",false);
    }
        
    IEnumerator StopMoveDuringAttack()
    {
        isWalkToPlayr = false;
        yield return new WaitForSeconds(0.5f);
        isWalkToPlayr = true;

    }

}
