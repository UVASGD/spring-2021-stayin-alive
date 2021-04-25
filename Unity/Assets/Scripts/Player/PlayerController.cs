using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Destructible
{
    public float movementSpeed = 1f;
    public Weapon mainWeapon;
	public GameObject crosshairs;
	// public GameObject enemy;
	// public PlayerData playerData;

	// Temporary, needs work
	public Sprite forward;
	public GameManager gm;
	public Sprite right;
	public bool reload = false;
	public float damage = 10f;
	public enum Characters
    {
		Hunter,
        Archer,
    }
	public Characters character;

	void Start(){
		// enemy = gameObject.Find("Enemy").GetComponent<Enemy>();
		// playerData = GameObject.Find("Player").GetComponent<PlayerData>();
		gm = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	public void SetChar(int charNum){
		if (charNum == 1){
			mainWeapon = GameObject.Find("Weapon").AddComponent<BaseGun>();
			//mainWeapon.gm = gm;
			character = Characters.Hunter;
			
		}
		if (charNum == 2){
			mainWeapon = GameObject.Find("Weapon").AddComponent<Bow>();
			//mainWeapon.gm = gm;
			character = Characters.Archer;
		}
	}

	void Update(){

	}

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
		mainWeapon.fireInput = fire;
		if (fire) {
			spriteRenderer.sprite = right;
			if (aim.x >= 0) {
				spriteRenderer.flipX = false;
			} else {
				spriteRenderer.flipX = true;
			}
			mainWeapon.Fire(transform.position, aim);
		}
		else
		{
			spriteRenderer.sprite = forward;
		}

		if (reload)
        {
			mainWeapon.Reload();
        }
		
	}

	public override void Die() {
		throw new System.NotImplementedException();
	}
}