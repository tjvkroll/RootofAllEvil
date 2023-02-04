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
    public bool isShooting, isJumping, isRooted, requireNewShootPress;

    public Transform barrelOffset;
    public float fireRate;
    public GameObject bulletPrefab;
    private float bulletTimer;


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
        controls.Player.Root.canceled += ctz => { isRooted = false; };

        main_cam = Camera.main;
        myController = GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bulletTimer += Time.deltaTime;
        if (isShooting && !requireNewShootPress) HandleShoot();
        myController.Move(leftStick.x, false, isJumping);
    }

    void HandleShoot()
    {
        if (bulletTimer < fireRate) return;
        requireNewShootPress = true;
        GameObject go = Instantiate(bulletPrefab, barrelOffset.position, barrelOffset.rotation);
        BulletBase bb = go.GetComponent<BulletBase>();
        Debug.Log(myController.FacingRight);
        bb.facingRight = myController.FacingRight;
        bulletTimer = 0;
    }
}
