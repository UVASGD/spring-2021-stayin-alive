using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float range;
    public float damage;
    public float bulletsPerSecond;
    public float reloadTime;
    public bool fireInput;
    
    public enum WeaponStates
    {
        Ready,
        Firing,
        Reloading,
    }
    public WeaponStates currentState = WeaponStates.Ready;

    public int maxAmmo; // In magazine
    public int currentAmmo; // In magazine
    public int totalAmmo; //on player (not in magazine)


    //TODO: change from timers/delays to a timestamp wherein it will adjust. 

    public virtual void Fire(Vector2 start, Vector2 aim) 
    {
        if (currentState != WeaponStates.Ready || currentAmmo <= 0)
        {
            return;
        }

        RaycastHit2D hit = Physics2D.Raycast(start, aim.normalized, range);

        if (hit)
        {
            Destructible destructible = hit.collider.GetComponent<Destructible>();
            if (destructible)
            {
                destructible.TakeDamage(damage);
            }
        }
        currentAmmo -= 1;
        StartCoroutine(BulletDelay()); //time delays require a seperate code block, which is below

    }
 
    public virtual void Reload()
    {
        if (currentState != WeaponStates.Ready)
        {
            return;
        }

        if (currentAmmo < maxAmmo && totalAmmo > 0)
        {
            StartCoroutine(ReloadTimings()); //time delays require a seperate code block, which is below
        }
    }

    public virtual IEnumerator BulletDelay()
    {
        currentState = WeaponStates.Firing;
        yield return new WaitForSeconds(1 / bulletsPerSecond);
        currentState = WeaponStates.Ready;
        if (currentAmmo <= 0)
        {
            Reload();
        }

    }

    public virtual IEnumerator ReloadTimings()
    {
        currentState = WeaponStates.Reloading;
        yield return new WaitForSeconds(reloadTime);
        totalAmmo -= maxAmmo - currentAmmo;
        currentAmmo = maxAmmo;
        if (totalAmmo < 0)
        {
            currentAmmo += totalAmmo;
            totalAmmo = 0;
        }
       currentState = WeaponStates.Ready;
    }
    
}