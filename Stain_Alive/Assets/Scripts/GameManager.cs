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
    public Button restartButton;
    public Button startButton;
    public TextMeshProUGUI gameoverText;
    public TextMeshProUGUI ammoText;
    public Slider healthBar;
    private int ammo;

    // Non UI Fields
    public bool isActive = false;
    public GameObject[] enemy;
    // public GameObject spawnManager;
    public PlayerData playerData;
    public float spawnDelay = 4;
    public float spawnRate = 1000;

    // Start is called before the first frame update
    void Start()
    {
        // SpawnWave();
        startButton.gameObject.GetComponent<Button>();
        startButton.onClick.AddListener(StartGame);
        healthBar.gameObject.GetComponent<Slider>();
        playerData = GameObject.Find("Player").GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerData.health == 0) {
            Gameover();
        }
        if (isActive) {
            StartCoroutine(Spawn());
        }
    }

    // Start the game
    public void StartGame() {
        isActive = true;
        titleScreen.SetActive(false);
        ammoText.gameObject.SetActive(true);
        healthBar.gameObject.SetActive(true);
    }

    // Method for showing gameover UI
    public void Gameover() {
        isActive = false;
        restartButton.gameObject.SetActive(true);
        gameoverText.gameObject.SetActive(true);
        ammoText.gameObject.SetActive(false);
    }

    // Restarts the game
    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Spawn Enemies
    IEnumerator Spawn() {
        
        yield return new WaitForSeconds(spawnDelay);
        SpawnWave();
    }

    private void SpawnWave() {
        int index = Random.Range(0, enemy.Length);
        Instantiate(enemy[index], GenerateSpawnPos(), enemy[index].transform.rotation);
    }

    private Vector3 GenerateSpawnPos() {
        float spawnPosX = Random.Range(-26, 17);
        float spawnPosY = Random.Range(-7, 30);
        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, 0);
        return randomPos;
    }
}
