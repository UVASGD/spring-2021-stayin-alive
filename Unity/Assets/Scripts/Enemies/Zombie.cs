using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
	void Start()
	{
		speed = 1f;
		aggroRange = 7f;
    	meleeRange = 1.8f;
		closeRange = 1.5f;
		swingTimer = 2;
		damage = 10;
		hitPoints = 100;
		maxHealth = 100;
	}

}
