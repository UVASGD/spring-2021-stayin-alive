﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLvl : MonoBehaviour
{

    public string lvlToLoad;
    

    void OnTriggerEnter2D(Collider2D other){

        if (other.CompareTag("Player")){
            SceneManager.LoadScene(lvlToLoad);
        }
    }
}
