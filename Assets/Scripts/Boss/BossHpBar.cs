using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class BossHpBar : MonoBehaviour
{
    public EnemHealthScr enemHealthScr;
    public UnityEngine.UI.Image HPbar;

    private void Start() 
    {
        enemHealthScr = GetComponent<EnemHealthScr>();
    }
    void Update()
    {
        HPbar.fillAmount = enemHealthScr._currentEnemyHealth/enemHealthScr._maxEnemyHealth;
    }
}
