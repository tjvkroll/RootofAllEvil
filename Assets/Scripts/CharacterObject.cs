using System;
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
    public float shootAnimCD;
    public bool shootAnim;

    public Animator anim;


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
        controls.Player.Root.performed += ctx => { HandleRoot(true); };
        controls.Player.Root.canceled += ctz => { HandleRoot(false); };

        main_cam = Camera.main;
        myController = GetComponent<CharacterController2D>();
        anim = GetComponentInChildren<Animator>();
    }

    public void HandleRoot(bool v)
    {
        if (v && myController.Grounded)
        {
            isRooted = true;
        }
        else
        {
            isRooted = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        shootAnimCD -= 1; // Stay in the shooting pose for a bit even after shooting or between shots. 
        bulletTimer += Time.deltaTime;
        if (isShooting && !requireNewShootPress) HandleShoot();
        if (isRooted)
        {
            moveSpeed = 0;
        }
        else
        {
            moveSpeed = 1;
        }
        myController.Move(leftStick.x * moveSpeed, false, isJumping);
        HandleAnimation();
    }

    void HandleAnimation()
    {
        if (shootAnimCD <= 0)
        {
            shootAnim = false;
        }
        else
        {
            shootAnim = true;
        }
        anim.SetFloat("Speed", Mathf.Abs(leftStick.x * moveSpeed));
        anim.SetBool("Rooted", isRooted);
        anim.SetBool("Shooting", shootAnim);
    }

    void HandleShoot()
    {
        if (isRooted) return; // no shooting while rooted.
        if (bulletTimer < fireRate) return;
        requireNewShootPress = true;
        GameObject go = Instantiate(bulletPrefab, barrelOffset.position, barrelOffset.rotation);
        BulletBase bb = go.GetComponent<BulletBase>();
        bb.facingRight = myController.FacingRight;
        bulletTimer = 0;
        shootAnimCD = 30;
    }

    public void ApplyForce(Vector2 direction, float power)
    {
        if (isRooted) return;
        myController.ApplyForce(direction, power);
    }
}
