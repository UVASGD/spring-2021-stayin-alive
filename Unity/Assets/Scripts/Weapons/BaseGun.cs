﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGun : Weapon
{
    public void Start()
    {
        range = 2;
        damage = 50;
        bulletsPerSecond = 1;
        reloadTime = 3;
        maxAmmo = 5;
        currentAmmo = 5;
        totalAmmo = 30;
        gm.UpdateAmmo(currentAmmo);
    }

}
