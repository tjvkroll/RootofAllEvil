using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterObject : MonoBehaviour
{
  private CharacterController2D myController;
  private ControlMap controls;
  public float moveSpeed;
  private Vector2 leftStick;
  private Camera main_cam;
  public bool isShooting, isJumping, isRooted;


  void OnEnable() { controls.Enable(); }

  void OnDisable() { controls.Disable(); }

  void Awake()
  {
    controls = new ControlMap();
    controls.Player.Move.performed += ctx => { leftStick = ctx.ReadValue<Vector2>(); };
    controls.Player.Move.canceled += ctx => { leftStick = new Vector2(0, 0); };
    controls.Player.Shoot.performed += ctx => { isShooting = true; };
    controls.Player.Shoot.canceled += ctx => { isShooting = false; };
    controls.Player.Jump.performed += ctx => { isJumping = true; };
    controls.Player.Jump.canceled += ctx => { isJumping = false; };
    controls.Player.Root.performed += ctx => { isRooted = true; };
    controls.Player.Root.canceled += ctz => { isRooted = false; };

    main_cam = Camera.main;
    myController = GetComponent<CharacterController2D>();
  }



  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void FixedUpdate()
  {
    myController.Move(leftStick.x, false, isJumping);
  }
}
