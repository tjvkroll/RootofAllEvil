using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
  public bool isFriendly = false;

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Bullet"))
    {
      BulletBase bb = other.GetComponent<BulletBase>();
      if (bb.isFriendly == isFriendly) { return; }

      Destroy(other.gameObject);
      BroadcastMessage("OnTakeDamage", bb.damage, SendMessageOptions.DontRequireReceiver);
    }
    else if (other.CompareTag("Enemy"))
    {
      EnemyDamage ed = other.GetComponent<EnemyDamage>();
      BroadcastMessage("OnTakeDamage", ed.damage, SendMessageOptions.DontRequireReceiver);
      // dont damage other enemies?

    }
  }
}
