using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    private HealthPlayer healthPlayer;
    public int CurrentHealthPotion;
    public int MaxCurrentHealthPotion = 3;
    public TextMeshProUGUI TextHPCurrent;
    private void Awake() 
    {
        healthPlayer = GetComponent<HealthPlayer>();
    }
    void Start()
    {
        CurrentHealthPotion = MaxCurrentHealthPotion;
    }
    void Update()
    {
        ActiveHealthPoition();
        TextHPCurrentUpdate();
    }
    public void ActiveHealthPoition()
    {
        if(Input.GetKeyDown(KeyCode.E) && CurrentHealthPotion>0 && healthPlayer._currentHealthPlayer<100)
        {
            CurrentHealthPotion--;
            healthPlayer._currentHealthPlayer += 20;
        }
    }
    public void TextHPCurrentUpdate()
    {
        TextHPCurrent.text = CurrentHealthPotion.ToString() + "/" + MaxCurrentHealthPotion.ToString();
    }
}
