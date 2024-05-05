using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public int collisionDamage;
    public string collisionTag;
    private void OnTriggerEnter2D(Collider2D other) 
    {

        if (other.gameObject.tag == collisionTag)
        {
            HealthPlayer healthPlayer = other.gameObject.GetComponent<HealthPlayer>();
            healthPlayer.TakeHit(collisionDamage);
        }        
    }
}
