using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpell : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;
    private void Start() 
    {
        StartCoroutine(SpellIsAttack());
    }
    void Update()
    {
        Destroy(gameObject,1.3f);
    }
    IEnumerator SpellIsAttack()
    {
        yield return new WaitForSeconds(0.3f);
        boxCollider2D.enabled = true;
        yield return new WaitForSeconds(0.1f);
        boxCollider2D.enabled = false;

    }
}
