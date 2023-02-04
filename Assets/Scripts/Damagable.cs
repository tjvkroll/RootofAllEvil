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

  private void OnTriggerEnter2D(Collider2D other)
  {
    Debug.Log("Triggered!");
    if (other.CompareTag("Bullet"))
    {
      Debug.Log("BulleetTrigger");
      BulletBase bb = other.GetComponent<BulletBase>();
      if (bb.isFriendly == isFriendly) { return; }

      Destroy(other.gameObject);
      BroadcastMessage("OnTakeDamage", bb.damage, SendMessageOptions.DontRequireReceiver);
    }
  }
}
