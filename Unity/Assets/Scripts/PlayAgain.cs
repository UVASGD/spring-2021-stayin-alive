using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{

    public Button restartButton;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        Destroy(GameObject.Find("Player"));

        restartButton.gameObject.GetComponent<Button>();
        restartButton.onClick.AddListener(RestartGame);
    }

    // Restarts the game
    public void RestartGame() {
        SceneManager.LoadScene("GrassLvl1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
