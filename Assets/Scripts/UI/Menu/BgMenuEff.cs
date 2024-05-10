using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMenuEff : MonoBehaviour
{public Transform target;
    public Vector3 pose;
    private Vector3 velocity;
    public float speed = 0.1f;


    void FixedUpdate()
    {

        pose.x = Mathf.SmoothDamp(pose.x, target.position.x, ref velocity.x, speed);
        pose.y = Mathf.SmoothDamp(pose.y, target.position.y, ref velocity.y, speed);
        transform.position = pose;


    }
}
