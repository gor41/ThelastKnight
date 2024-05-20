using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfDownPlayer : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            HealthPlayer.Instance._currentHealthPlayer = 0;
        }
    }
}
