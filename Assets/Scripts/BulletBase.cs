using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    public bool facingRight;
    public float moveSpeed;
    // Update is called once per frame
    void FixedUpdate()
    {
        int modi = 1;
        if (!facingRight) { modi = -1; }
        transform.position += Vector3.right * moveSpeed * modi;
    }
}
