using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
  public bool isFriendly = false;

  /* POSSIBLE EXPLOSION HANDLING */
  //   public void HandleExplosion(Explode explosion)
  //   {
  //     if (explosion.isFriendly == isFriendly) return;
  //     // knockback
  //     BroadcastMessage("OnExplosionKnockback", explosion, SendMessageOptions.DontRequireReceiver);
  //     // HP
  //     BroadcastMessage("OnTakeDamage", explosion.explosionPower, SendMessageOptions.DontRequireReceiver);
  //   }

  //   private void OnTriggerEnter(Collider other)
  //   {
  //     if (other.CompareTag("Bullet"))
  //     {
  //       BulletBase bb = other.GetComponent<BulletBase>();
  //       if (bb.isFriendly == isFriendly) { return; }
  //       if (bb.explosive)
  //       {
  //         bb.CreateExplosion();
  //         Destroy(other.gameObject);
  //       }
  //       if (!bb.piercing)
  //       {
  //         Destroy(other.gameObject);
  //       }
  //       BroadcastMessage("OnBulletKnockback", bb, SendMessageOptions.DontRequireReceiver);
  //       BroadcastMessage("OnTakeDamage", bb.damage, SendMessageOptions.DontRequireReceiver);
  //     }
  //   }
}
