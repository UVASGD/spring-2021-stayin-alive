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
    public float projectileSpeed;
    
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
    public GameManager gm;
    public AudioSource[] source;  //[0] is shoot bullet, [1] is reload gun, [2] is draw bow, [3] is release bow
    public GameObject bulletPrefab;


    void Awake(){
        //for some reason I (maybe) can't assign gm here but it gets assigned when PlayerController creates the weapon
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        source = GameObject.Find("Weapon").GetComponents<AudioSource>();
        SetBullet();
        // bulletPrefab = GameObject.Find("Weapon").GetComponent<BulletHolder>().bulletPrefab[1];
        // if (gm.playerIndex == 1) {
        //     bulletPrefab = GameObject.Find("Weapon").GetComponent<BulletHolder>().bulletPrefab[0];
        // }
        // else if (gm.playerIndex == 2) {
        //     bulletPrefab = GameObject.Find("Weapon").GetComponent<BulletHolder>().bulletPrefab[1];
        // }
        //NOTE: include gm.UpdateAmmo(currentAmmo); at the end of each weaponType's start function since its wonky being here
    }

    public virtual void SetBullet() {
        
    }

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
        source[0].Play();
        GameObject a = Instantiate(bulletPrefab) as GameObject;
        a.transform.position = start;
        a.GetComponent<Rigidbody2D>().velocity = aim.normalized * projectileSpeed;

        if(hit){
           a.GetComponent<Bullet>().range = hit.distance; 
        }
        else{
            a.GetComponent<Bullet>().range = range; 
        }
        a.GetComponent<Bullet>().start = start;
        
        gm.UpdateAmmo(currentAmmo);
        StartCoroutine(BulletDelay()); //time delays require a seperate code block, which is below

    }
 
    public virtual void Reload()
    {
        StartCoroutine(ReloadTimings());
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
        yield return new WaitUntil(() => currentState == WeaponStates.Ready);
    
        if (currentAmmo < maxAmmo && totalAmmo > 0)
        {
            currentState = WeaponStates.Reloading;
            gm.UpdateAmmo(-1);
            source[1].Play();
            yield return new WaitForSeconds(reloadTime);

            //totalAmmo -= maxAmmo - currentAmmo;
            currentAmmo = maxAmmo;
            if (totalAmmo < 0)
            {
                currentAmmo += totalAmmo;
                totalAmmo = 0;
            }
            currentState = WeaponStates.Ready;
            gm.UpdateAmmo(currentAmmo);
        }
    }
    
}