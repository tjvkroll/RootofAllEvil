using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupMushroom : MonoBehaviour
{
    public float repeatTime = 10;
    public float timer;
    public float bulletTimer;
    public float fireRate;
    private Animator anim;
    public bool isShooting;
    public GameObject bulletPrefab;
    public HP hp;
    private List<Vector2> shootDirs;

    void Start()
    {
        shootDirs = new List<Vector2>();
        shootDirs.Add(Vector2.up);
        shootDirs.Add(Vector2.left);
        shootDirs.Add(Vector2.right);
        shootDirs.Add(new Vector2(1, 1));
        shootDirs.Add(new Vector2(-1, 1));
        anim = GetComponentInChildren<Animator>();
        anim.SetTrigger("show");
        hp = GetComponent<HP>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bulletTimer += Time.deltaTime;
        timer += Time.deltaTime;
        if (timer > repeatTime)
        {
            anim.SetTrigger("show");
            hp.isInvuln = false;
            timer = 0;
        }
        if (isShooting) OnShoot();
    }

    // The actual bullet generation
    public void OnShoot()
    {
        if (bulletTimer < fireRate) return;
        foreach (Vector2 direction in shootDirs)
        {
            // Instantiate() enemy bullets for each direction. vector2s given as unit circle from position.
        }
        bulletTimer = 0;
    }

    // Animation Event will call this to toggle it.
    public void Shoot(int toggle)
    {
        if (toggle != 0)
        {
            isShooting = true;
        }
        else
        {
            isShooting = false;
        }
    }
    // Animation event will call this
    public void Hide()
    {
        hp.isInvuln = true;
    }
}
