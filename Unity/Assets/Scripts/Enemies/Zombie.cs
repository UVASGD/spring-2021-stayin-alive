using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Destructible
{
	public override void Heal() {
		throw new System.NotImplementedException();
	}

	public override void TakeDamage() {
		Die();
	}

	public override void Die() {
		Destroy(gameObject);
	}
}
