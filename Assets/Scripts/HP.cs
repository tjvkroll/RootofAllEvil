using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public float maxHP;
    public float currentHP;
    public bool isInvuln;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    public void OnTakeDamage(float amt)
    {
        if (isInvuln) return;
        currentHP -= amt;
        if (currentHP <= 0) BroadcastMessage("OnDeath", null, SendMessageOptions.DontRequireReceiver);
    }
}
