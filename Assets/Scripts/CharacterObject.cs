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
  public bool newTree, isShooting, isJumping, isRooted, requireNewShootPress, requireNewTreePress;

  public Transform barrelOffset;
  public float fireRate;
  public GameObject bulletPrefab;
  public GameObject treeBulletPrefab;
  private float bulletTimer;
  public List<TreePlatform> treeList;
  public float maxTrees;

  void OnEnable() { controls.Enable(); }

  void OnDisable() { controls.Disable(); }

  void Awake()
  {
    controls = new ControlMap();
    controls.Player.Move.performed += ctx => { leftStick = ctx.ReadValue<Vector2>(); };
    controls.Player.Move.canceled += ctx => { leftStick = new Vector2(0, 0); };
    controls.Player.Shoot.performed += ctx => { isShooting = true; };
    controls.Player.Shoot.canceled += ctx => { isShooting = false; requireNewShootPress = false; };
    controls.Player.Jump.performed += ctx => { isJumping = true; };
    controls.Player.Jump.canceled += ctx => { isJumping = false; };
    controls.Player.Root.performed += ctx => { isRooted = true; };
    controls.Player.Root.canceled += ctx => { isRooted = false; };
    controls.Player.SpawnTree.performed += ctx => { newTree = true; };
    controls.Player.SpawnTree.canceled += ctx => { newTree = false; requireNewTreePress = false; };

    main_cam = Camera.main;
    myController = GetComponent<CharacterController2D>();
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    bulletTimer += Time.deltaTime;
    if (isShooting && !requireNewShootPress) HandleShoot();
    if (newTree && !requireNewTreePress) HandleTreeSpawn();
    myController.Move(leftStick.x, false, isJumping);
  }

  void HandleTreeSpawn()
  {
    requireNewTreePress = true;
    GameObject go = Instantiate(treeBulletPrefab, transform.position, transform.rotation);
  }

  void HandleShoot()
  {
    if (bulletTimer < fireRate) return;
    requireNewShootPress = true;
    GameObject go = Instantiate(bulletPrefab, barrelOffset.position, barrelOffset.rotation);
    BulletBase bb = go.GetComponent<BulletBase>();
    bb.facingRight = myController.FacingRight;
    bulletTimer = 0;
  }
}
