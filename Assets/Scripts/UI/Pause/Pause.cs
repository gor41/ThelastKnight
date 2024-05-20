using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PanelPause;
    private bool isActivePause = false;
    public PlayerScr playerScr;

    // Update is called once per frame
    void Update()
    {
        PauseActive();
    }
    public void PauseActive()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && isActivePause == false)
        {
            PanelPause.SetActive(true);
            isActivePause = true;
            Time.timeScale = 0f;
            playerScr.enabled = false;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isActivePause == true)
        {
            PanelPause.SetActive(false);
            isActivePause = false;
            Time.timeScale = 1f;
            playerScr.enabled = true;
        }
    }
}
