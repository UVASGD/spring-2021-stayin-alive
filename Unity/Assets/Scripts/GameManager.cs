using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // User Interaction Fields
    public GameObject titleScreen;
    public GameObject playerSelect;
    public Button restartButton;
    public Button startButton;
    public Button char1;
    public Button char2;
    public TextMeshProUGUI gameoverText;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI levelText;
    public Slider healthBar;
    public Image pistol;

    // Non UI Fields
    public bool isActive = false;
    public GameObject[] enemy;
    // public PlayerData playerData;
    public float spawnDelay = 0.05f;
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        startButton.gameObject.GetComponent<Button>();
        startButton.onClick.AddListener(ChooseCharacter);
        healthBar.gameObject.GetComponent<Slider>();
        pistol.gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // UpdateLevel();
    }

    public void ChooseCharacter() {
        titleScreen.SetActive(false);
        playerSelect.SetActive(true);
        char1.gameObject.GetComponent<Button>();
        char2.gameObject.GetComponent<Button>();
        char1.onClick.AddListener(Char1Selected);
        char2.onClick.AddListener(Char2Selected);
    }

    public void Char1Selected() {
        StartGame();
        player.SetChar(1);
    }

    public void Char2Selected() {
        StartGame();
        player.SetChar(2);
    }

    // Start the game
    public void StartGame() {
        isActive = true;
        playerSelect.SetActive(false);
        ammoText.gameObject.SetActive(true);
        healthBar.gameObject.SetActive(true);
        levelText.gameObject.SetActive(true);
        pistol.gameObject.SetActive(true);
        StartCoroutine(Spawn());
    }

    // Method for showing gameover UI
    public void Gameover() {
        isActive = false;
        restartButton.gameObject.SetActive(true);
        gameoverText.gameObject.SetActive(true);
        ammoText.gameObject.SetActive(false);
        levelText.gameObject.SetActive(false);
        pistol.gameObject.SetActive(false);
    }

    // Restarts the game
    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Spawn Enemies
    IEnumerator Spawn() {
        while (isActive) {
            yield return new WaitForSeconds(spawnDelay);
            SpawnWave();
        }
    }

    public void SpawnWave() {
        int index = Random.Range(0, enemy.Length);
        Instantiate(enemy[index], GenerateSpawnPos(), enemy[index].transform.rotation);
    }

    private Vector3 GenerateSpawnPos() {
        float spawnPosX = Random.Range(-26, 17);
        float spawnPosY = Random.Range(-7, 30);
        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, 0);
        return randomPos;
    }

    public void UpdateAmmo(int ammo) {
        if (ammo == -1){
            ammoText.text = "Reloading...";
            return;
        }
        ammoText.text = "Ammo: " + ammo;
    }

    public void UpdateLevel(string level) {
        // if (grid.CompareTag("lv1")) {
        //     levelText.text = "Level 1: Wasteland";
        //     return;
        // }
        // if (grid.CompareTag("lv2")) {
        //     levelText.text = "Level 2: The Labyrinth";
        //     return;
        // }
        // if (grid.CompareTag("lv3")) {
        //     levelText.text = "Level 3: Shadow Swamp";
        // }
        levelText.text = level;
    }
}
