using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneAsync : MonoBehaviour
{
    public string Scene = "";
    public Slider slider;

    public void Scen()
    {
        StartCoroutine(LoadNextScene());    
    }

    private IEnumerator LoadNextScene()
    {
        AsyncOperation oper = SceneManager.LoadSceneAsync(Scene);
        DataConroller.checkPointIndex = 0;

        while (!oper.isDone) 
        { 
            float progress = oper.progress/0.9f;
            slider.value = progress;
            yield return null;
        }
    }
}
