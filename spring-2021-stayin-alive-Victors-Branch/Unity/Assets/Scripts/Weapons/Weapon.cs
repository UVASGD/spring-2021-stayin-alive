using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float range;
    public float damage;
    public float bulletsPerSecond;

    public int maxAmmo; // In magazine
    public int currentAmmo; // In magazine
}
