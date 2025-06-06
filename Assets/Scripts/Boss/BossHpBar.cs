
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class BossHpBar : MonoBehaviour
{
    public EnemHealthScr enemHealthScr;
    public PlayableDirector EndCutScene;
    public UnityEngine.UI.Image HPbar;
    public GameObject DeadBoss;
    public GameObject BossMusic;
    private void Start() 
    {
        enemHealthScr = GetComponent<EnemHealthScr>();
    }
    void Update()
    {
        HPbar.fillAmount = enemHealthScr._currentEnemyHealth/enemHealthScr._maxEnemyHealth;
        Dead();
    }
    public void Dead()
    {
        if(enemHealthScr._currentEnemyHealth <= 0)
        {
            StartCoroutine(DeadCoroutine());;
        }
}
IEnumerator DeadCoroutine()
{
    BossMusic.SetActive(false);
    EndCutScene.Play();
    Instantiate(DeadBoss,transform.position, Quaternion.identity);
    yield return new WaitForSeconds(0);
}
}
