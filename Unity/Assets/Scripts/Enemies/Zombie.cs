using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
	void Start()
	{
		speed = 1f;
		aggroRange = 10f;
    	meleeRange = 1.8f;
		closeRange = 1.5f;
		swingTimer = 2f;
		damage = 10f;
		hitPoints = 100f;
		maxHealth = 100f;
	}

}
