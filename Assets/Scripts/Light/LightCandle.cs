using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCandle : MonoBehaviour
{
    private Light lightPoint;
    public float powerLight;
    public float TimeLight;

    private void Awake() {
        lightPoint = GetComponent<Light>();
    }
    private void FixedUpdate() 
    {
        lightPoint.intensity = Mathf.PerlinNoise(Time.time * TimeLight,0) * powerLight;
        
    }
    
}
