using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCutScene : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.right.normalized * 12 * Time.deltaTime);
        Invoke("Delete",2f);
    }
    void Delete()
    {
        Destroy(gameObject);

    }
}
