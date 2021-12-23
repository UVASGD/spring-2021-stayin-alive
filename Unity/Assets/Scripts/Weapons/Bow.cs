using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Weapon //Current implementation makes this only doable by main player
{
    public float rangeIncrease;  
    public float damageIncrease;
    public float maxDamage;
    public float maxRange;          
    public bool testVar;
    
    public Vector2 start;
    public Vector2 aim;
    const float startingRange = 1;
    const float startingDamage = 10;

    public override void SetBullet() {
        bulletPrefab = GameObject.Find("Weapon").GetComponent<BulletHolder>().bulletPrefab[1];
    }

    void Start()
    {
        range = startingRange;
        damage = startingDamage;               
        reloadTime = .01f;
        maxAmmo = 10;
        currentAmmo = 3;
        totalAmmo = 30;
        bulletsPerSecond = 1;
        projectileSpeed = 15;
        rangeIncrease = 2.67f;     //From here...
        damageIncrease = 33.4f;
        maxDamage = 100;
        maxRange = 8;             //...To here, make sure "increase" vars divide "max" vars evenly
        gm.UpdateAmmo(-2);
    }

    // Update is called once per frame
    void Update()
    {

        if (currentState == WeaponStates.Firing)
        {
            if (range < maxRange)
            {
                range += rangeIncrease * Time.deltaTime;
            }
            if (damage < maxDamage)
            {
                damage += damageIncrease * Time.deltaTime;
            }
            if (!fireInput)
            {
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
                source[2].Stop();
                source[3].Play();
                gm.UpdateAmmo(-2);
                //create bullet
                GameObject a = Instantiate(bulletPrefab) as GameObject;
                a.transform.position = start;
                float angle = Vector2.Angle(aim, new Vector2(1f,0f));
                if (aim.y <= 0){
                    angle = -angle;
                }
                a.transform.Rotate(0,0, angle);
                a.GetComponent<Rigidbody2D>().velocity = aim.normalized * projectileSpeed;

                if (hit){
                    a.GetComponent<Bullet>().range = hit.distance; 
                }
                else{
                    a.GetComponent<Bullet>().range = range; 
                }

                a.GetComponent<Bullet>().start = start;
                //reset
                damage = startingDamage;
                range = startingRange;
                StartCoroutine(BulletDelay());
            }
        }
    }


    public override void Fire(Vector2 start, Vector2 aim)
    {
        //this is a wonky method to get the player's location and aim vectors (as it only retrives when clicking to fire), but I think its best considering most other weapons (should) only need them in the Fire() function, but we can change when we get there
        //Narrator voice: "good thing they never got there"
        this.start = start;
        this.aim = aim;                         
        if (currentState != WeaponStates.Ready || currentAmmo <= 0)
        {
            return;
        }
        source[2].Play();
        currentState = WeaponStates.Firing;
    }

    public override IEnumerator BulletDelay()
    {
        currentState = WeaponStates.Reloading;
        yield return new WaitForSeconds(1 / bulletsPerSecond);
        currentState = WeaponStates.Ready;
        if (currentAmmo <= 0)
        {
            Reload();
        }

    }

    public override IEnumerator ReloadTimings()
    {
        yield return new WaitUntil(() => currentState == WeaponStates.Ready);
    
        if (currentAmmo < maxAmmo && totalAmmo > 0)
        {
            currentState = WeaponStates.Reloading;
            gm.UpdateAmmo(-2);
            yield return new WaitForSeconds(reloadTime);

            //totalAmmo -= maxAmmo - currentAmmo;
            currentAmmo = maxAmmo;
            if (totalAmmo < 0)
            {
                currentAmmo += totalAmmo;
                totalAmmo = 0;
            }
            currentState = WeaponStates.Ready;
            gm.UpdateAmmo(-2);
        }
    }

}
