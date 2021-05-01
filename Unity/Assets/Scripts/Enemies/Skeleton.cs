using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    void Start()
	{
		speed = 1.2f;
		aggroRange = 12f;
    	meleeRange = 2f;
		closeRange = 1.6f;
		swingTimer = .75f;
		damage = 4f;
		hitPoints = 50f;
		maxHealth = 50f;
	}
}
