using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectScene : MonoBehaviour
{
    public float TimeToDestroy;
   private void Update() 
   {
    Destroy(gameObject, TimeToDestroy);
   }
}
