using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Destructible
{
	void Start()
    {
		hitPoints = 100;
		maxHealth = 100;
    }

	public override void Die() {
		Destroy(gameObject);
	}
}
