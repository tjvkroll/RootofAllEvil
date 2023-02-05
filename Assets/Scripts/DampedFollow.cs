using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DampedFollow : MonoBehaviour
{
    public Transform followTrans;
    public float time = 0.1f; // how fast to catch up
    private Vector3 velocity;

    void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, followTrans.position, ref velocity, time);
    }
}
