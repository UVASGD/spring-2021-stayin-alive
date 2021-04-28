using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SafeHouse : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.CompareTag("Player")) {
			if (this.CompareTag("2 to 3")) {
				SceneManager.LoadScene("GrassLvl3");
			}
			else if (this.CompareTag("3 to win")) {
				SceneManager.LoadScene("Victory");
			}
		}
	}
}
