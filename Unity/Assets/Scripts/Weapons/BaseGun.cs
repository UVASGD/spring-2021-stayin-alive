using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGun : Weapon
{
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
