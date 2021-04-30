using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : Destructible
{
    public float movementSpeed = 5f;
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
		
	}

	public void SetChar(int charNum){
		if (charNum == 1){
			mainWeapon = GameObject.Find("Weapon").AddComponent<BaseGun>();
			character = Characters.Hunter;
		}
		if (charNum == 2){
			mainWeapon = GameObject.Find("Weapon").AddComponent<Bow>();
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

		// Weapon control
		mainWeapon.fireInput = fire;

		if (fire && mainWeapon.currentState != Weapon.WeaponStates.Reloading) { 
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

	public override void TakeDamage(float amount)
    {
        this.hitPoints -= amount;
		gm.UpdateHealth(hitPoints);
        if (hitPoints <= 0)
        {
            Die();
        }
    }

	public override void TakeDamage()
    {
		gm.UpdateHealth(0);
		Die();
    }

	public override void Die() {
		gm.GameOver();
	}

	public void Awake() {
		DontDestroyOnLoad(this.gameObject);
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.CompareTag("1 to 2")) {
			this.transform.position = new Vector3(-10, 0, 0);
			gm.UpdateLevel("Level 2: The Labyrinth");
			SceneManager.LoadScene("GrassLvl2");
		}
		if (collision.CompareTag("2 to 3")) {
			this.transform.position = new Vector3(-10, 0, 0);
			gm.UpdateLevel("Level 3: Shadow Swamp");
			SceneManager.LoadScene("GrassLvl3");
		}
		if (collision.CompareTag("3 to win")) {
			Destroy(gameObject);
			gm.isActive = false;
			SceneManager.LoadScene("Victory");
		}
	}

}