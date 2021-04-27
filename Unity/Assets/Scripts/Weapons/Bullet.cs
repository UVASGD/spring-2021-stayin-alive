using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float range;
    private Rigidbody2D rb;
    private Weapon mainWeapon;
    private GameObject player;
    public Vector2 start;

    // Start is called before the first frame update
    void Start()
    {
        mainWeapon = GameObject.Find("Weapon").GetComponent<Weapon>();
        player = GameObject.Find("Player");
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //thanks pythagoras and boo why isnt there a power operator in c#
        if((transform.position.x - start.x) * (transform.position.x - start.x) + (transform.position.y - start.y) * (transform.position.y - start.y) > range * range){
            Destroy(this.gameObject);
        }
    }

    

}
