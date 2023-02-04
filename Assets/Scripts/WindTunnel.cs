using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTunnel : MonoBehaviour
{
    public float power;
    public bool facingRight;
    void OnTriggerStay2D(Collider2D other)
    {
        CharacterController2D cc = other.GetComponent<CharacterController2D>();
        if (!cc) return;
        Debug.Log("Trigger STay!");
        int modi = 1;
        if (!facingRight) modi = -1;
        cc.ApplyForce(new Vector2(modi, 0), power);
    }
}
