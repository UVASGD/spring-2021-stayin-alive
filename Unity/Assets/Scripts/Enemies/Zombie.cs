using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
	void Start()
	{
		speed = 1f;
		aggroRange = 5f;
    	meleeRange = 1.5f;
		swingTimer = 2;
		damage = 10;
		hitPoints = 100;
		maxHealth = 100;
	}

}
