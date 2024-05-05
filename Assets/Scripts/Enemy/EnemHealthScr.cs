using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemHealthScr : MonoBehaviour
{
    [SerializeField] public float _currentEnemyHealth;
    [SerializeField] public float _maxEnemyHealth = 200f;
    
    private void Awake() 
    {
     _currentEnemyHealth = _maxEnemyHealth;   
    }

    public void TakeHitEnemy(int damage)
    {
        _currentEnemyHealth -= damage;
    }
    private void Update() 
    {
        if(_currentEnemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    
}
