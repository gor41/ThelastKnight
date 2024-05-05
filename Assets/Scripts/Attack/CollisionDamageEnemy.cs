using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamageEnemy : MonoBehaviour
{
    public int collisionDamageEnemy = 10;
    public string collisionTag;
    private void OnTriggerEnter2D(Collider2D other) 
    {
     if (other.gameObject.tag == collisionTag)
        {
            EnemHealthScr enemHealthScr = other.gameObject.GetComponent<EnemHealthScr>();
            enemHealthScr.TakeHitEnemy(collisionDamageEnemy);

        }   
    }
}

