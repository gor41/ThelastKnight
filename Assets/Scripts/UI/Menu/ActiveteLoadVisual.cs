using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveteLoadVisual : MonoBehaviour
{
    public GameObject LoadImage;
    
    public void Active()
    {
        LoadImage.SetActive(true);
    }
}
