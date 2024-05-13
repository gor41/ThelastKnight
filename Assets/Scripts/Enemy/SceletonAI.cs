using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceletonAI : MonoBehaviour
{
    public float SceletSpeed;
    public LayerMask PlayerIsLayer;
    public GameObject AttackBoxScelet;
    public Transform Startpoint;
    private Animator animator;
    private Transform player;
    private bool isFlipped = false;

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
        if (Vector2.Distance(transform.position, player.position) < 5)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPlayer, SceletSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, tarhetStartPoint, SceletSpeed * Time.deltaTime);
        }
    }
    public void AttackScelet()
    {

    }

}
