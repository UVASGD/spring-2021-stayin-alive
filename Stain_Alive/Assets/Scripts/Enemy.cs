using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Destructible
{
    public float speed = 0.001f;
    private Rigidbody2D enemyRb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookDirection = player.transform.position - transform.position;
        // enemyRb.AddForce(lookDirection * speed, ForceMode2D.Impulse);
        // enemyRb.MovePosition(player.transform.position);
    }
}
