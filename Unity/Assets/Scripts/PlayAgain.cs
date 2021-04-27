using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{

    public Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        restartButton.gameObject.GetComponent<Button>();
        restartButton.onClick.AddListener(RestartGame);
    }

    // Restarts the game
    public void RestartGame() {
        SceneManager.LoadScene("GrassLvl2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
