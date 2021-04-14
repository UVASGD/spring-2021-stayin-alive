using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
	// temporary, deleet after demo
	public GameObject zombieGroup;

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.CompareTag("Player")) {
			zombieGroup.SetActive(true);
		}
	}
}
