using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public void Switch(int num)
    {
        SceneManager.LoadScene(num);
        Time.timeScale = 1f;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
