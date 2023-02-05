using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTunnel : MonoBehaviour
{
    public float power;
    public bool facingRight;
    void OnTriggerStay2D(Collider2D other)
    {
        CharacterObject co = other.GetComponent<CharacterObject>();
        if (!co) return;
        Debug.Log("Trigger STay!");
        int modi = 1;
        if (!facingRight) modi = -1;
        co.ApplyForce(new Vector2(modi, 0), power);
    }
}
