using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
  public CharacterController2D myController;
  public float moveSpeed;
  public float attackRange;
  public bool FacingRight;
  [SerializeField] private Transform FallCheck;
  [SerializeField] private LayerMask WhatIsGround;
  const float GroundedRadius = .2f;

  // Start is called before the first frame update
  void Start()
  {
    myController = GetComponent<CharacterController2D>();
    FacingRight = true;
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    if (!Physics2D.OverlapCircle(FallCheck.position, GroundedRadius, WhatIsGround))
    {
      FacingRight = !FacingRight;
    }
    int modi = 1;
    if (!FacingRight) modi = -1;
    float targetVelocity = moveSpeed * modi;
    myController.Move(targetVelocity, false, false);
  }

  void OnDeath()
  {
    Destroy(this.gameObject);
  }


}
