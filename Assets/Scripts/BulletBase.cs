using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
  public bool facingRight, isFriendly;
  public float moveSpeed, TTL, damage;
  public AudioSource efx;

  void Start()
  {
    efx.Play();
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    TTL -= Time.deltaTime;
    if (TTL <= 0)
    {
      Destroy(this.gameObject);
    }
    int modi = 1;
    if (!facingRight) { modi = -1; }
    transform.position += Vector3.right * moveSpeed * modi;
  }
}
