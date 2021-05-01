using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGun : Weapon
{

    public override void SetBullet() {
        bulletPrefab = GameObject.Find("Weapon").GetComponent<BulletHolder>().bulletPrefab[0];
    }

    public void Start()
    {
        range = 4;
        damage = 50;
        bulletsPerSecond = 1;
        reloadTime = 3;
        maxAmmo = 5;
        currentAmmo = 5;
        totalAmmo = 30;
        projectileSpeed = 10f;
        gm.UpdateAmmo(currentAmmo);
    }

}
