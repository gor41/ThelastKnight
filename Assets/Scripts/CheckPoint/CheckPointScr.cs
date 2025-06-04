using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScr : MonoBehaviour
{
    public Transform player;
    public int index;
    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (DataConroller.checkPointIndex == index)
        {
            player.position = transform.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (index > DataConroller.checkPointIndex)
            {
                DataConroller.checkPointIndex = index;
            }
        }
    }
}
