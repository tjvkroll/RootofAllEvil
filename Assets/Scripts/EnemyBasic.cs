using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{

  [GradientUsageAttribute(true)]
  public Gradient onHitBodyGradient;
  public float flashOnHitDuration = 0.5f;


  public void OnTakeDamage(float dummy)
  {
    StartCoroutine(DamageBlink(1));
  }

  public void OnDeath()
  {
    Destroy(this.gameObject);
  }

  IEnumerator DamageBlink(int blinkCount)
  {
    Material mat = GetComponentInChildren<Renderer>().material;
    for (int i = 0; i < blinkCount; i++)
    {
      float blink_start = Time.time;
      while (Time.time - blink_start < flashOnHitDuration)
      {
        Color currentColor = onHitBodyGradient.Evaluate((Time.time - blink_start) / flashOnHitDuration);
        mat.SetColor("_EmissionColor", currentColor);
        yield return null;
      }
    }
    mat.SetColor("_EmissionColor", Color.black);
  }
}
