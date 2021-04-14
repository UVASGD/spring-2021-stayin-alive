using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Destructible
{
    public float movementSpeed = 1f;
    public Weapon mainWeapon;
	public GameObject crosshairs;

	// Temporary, needs work
	public Sprite forward;
	public Sprite right;

	public SpriteRenderer spriteRenderer;

	public void ProcessInput(Vector2 movement, Vector2 aim, bool fire) {
        transform.Translate(movement * movementSpeed * Time.deltaTime); // moves character in specified directions

		Debug.DrawRay(transform.position, aim.normalized * mainWeapon.range, Color.red);

		// position crosshairs
		if(aim.magnitude < mainWeapon.range) {
			crosshairs.transform.position = (Vector2) transform.position + aim;
		} else {
			crosshairs.transform.position = (Vector2) transform.position + (aim.normalized * mainWeapon.range);
		}
		
		// fire weapon
		if (fire) {
			if(aim.x >= 0) {
				spriteRenderer.sprite = right;
				spriteRenderer.flipX = false;
			} else {
				spriteRenderer.sprite = right;
				spriteRenderer.flipX = true;
			}
            Fire(aim);
		} 
		
		else {
			spriteRenderer.sprite = forward;
		}
	}

    public void Fire(Vector2 direction) {
        RaycastHit2D bullet = Physics2D.Raycast(transform.position, direction.normalized, mainWeapon.range);

		if (bullet) {
			Debug.Log(bullet.collider.gameObject.name);
			Zombie zombie = bullet.collider.GetComponent<Zombie>();
			if (zombie) {
				zombie.TakeDamage();
			}
		}
	}

	public override void TakeDamage() {
		throw new System.NotImplementedException();
	}

	public override void Heal() {
		throw new System.NotImplementedException();
	}
}
