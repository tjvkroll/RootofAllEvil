using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawn : MonoBehaviour
{
  const float checkRad = .2f;
  [SerializeField] private LayerMask whatIsGround;
  public GameObject treePrefab;
  public float moveSpeed;
  // Update is called once per frame


  void Update()
  {
    if (Physics2D.OverlapCircle(transform.position, checkRad, whatIsGround))
    {
      GameObject go = Instantiate(treePrefab, transform.position, transform.rotation);
      Destroy(this.gameObject);
    }
    transform.position += Vector3.down * Time.deltaTime * moveSpeed;
  }
}
