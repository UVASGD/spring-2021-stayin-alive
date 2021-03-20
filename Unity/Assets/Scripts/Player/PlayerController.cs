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

	public void ProcessInput(Vector2 movement, Vector2 aim, bool fire, bool reload) {
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
			mainWeapon.Fire(transform.position, aim);
		} 

		if (reload)
        {
			mainWeapon.Reload();
        }
		
		else {
			spriteRenderer.sprite = forward;
		}
	}

	public override void Die() {
		throw new System.NotImplementedException();
	}
}
