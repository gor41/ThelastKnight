using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    public GameObject settingsPanel;
    private bool isActive = false;
    public void SettingsUp()
    {
        if (isActive == false)
        {
            settingsPanel.SetActive(true);
            isActive = true;
        }
        else if(isActive == true)
        {
            settingsPanel.SetActive(false);
            isActive = false;
        }
    }
}
