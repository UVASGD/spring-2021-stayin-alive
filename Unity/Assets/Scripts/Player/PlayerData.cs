using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    public static PlayerData singleton;

    public float health;
    public float maxHealth;
    public int reserveAmmo;

    // private void Awake() {
    //     if (singleton == null) {
    //         singleton = this;
    //     } else {
    //         Destroy(gameObject);
    //     }

    //     DontDestroyOnLoad(gameObject);
    // }

    // Initialize fields here
    void Start() {
        
    }

    // Reset player data after death / restart of game
    public void ResetState() {
        
    }
}
