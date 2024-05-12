using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceletonAI : MonoBehaviour
{
    public float SceletSpeed;
    public LayerMask PlayerIsLayer;
    public GameObject AttackBoxScelet;
    private int _randomPoint;
    public Transform[] point;

    private Animator animator;

    private Transform player;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }
    void Start()
    {
        _randomPoint = Random.Range(0, point.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, point[_randomPoint].position, SceletSpeed * Time.deltaTime);

        if(Vector2.Distance(transform.position,point[_randomPoint].position) < 0.2f)
        {
            _randomPoint = Random.Range(0, point.Length);
            transform.Rotate(0, -180f, 0);
        }

    }

}
