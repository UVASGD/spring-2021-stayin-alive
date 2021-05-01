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
    public Image shotgun;
    public Image bow;

    // Non UI Fields
    public bool isActive = false;
    public GameObject[] enemy;
    // public PlayerData playerData;
    public int spawnDelay = 2;
    public PlayerController player;
    public int playerIndex;

    // Start is called before the first frame update
    void Start()
    {
        startButton.gameObject.GetComponent<Button>();
        startButton.onClick.AddListener(ChooseCharacter);
        healthBar.gameObject.GetComponent<Slider>();
        shotgun.gameObject.GetComponent<Image>();
        bow.gameObject.SetActive(false);
        // player_sprite = gameObject.GetComponent<SpriteRenderer>();
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
        // player.ChangeSprite(1);
        StartGame();
        player.SetChar(1);
        playerIndex = 1;
        shotgun.gameObject.SetActive(true);

    }

    public void Char2Selected() {
        // player.ChangeSprite(2);
        StartGame();
        player.SetChar(2);
        playerIndex = 2;
        bow.gameObject.SetActive(true);
    }

    // Start the game
    public void StartGame() {
        isActive = true;
        playerSelect.SetActive(false);
        ammoText.gameObject.SetActive(true);
        healthBar.gameObject.SetActive(true);
        levelText.gameObject.SetActive(true);
        // pistol.gameObject.SetActive(true);
        StartCoroutine(Spawn());
    }

    // Method for showing gameover UI
    public void GameOver() {
        isActive = false;
        restartButton.gameObject.SetActive(true);
        gameoverText.gameObject.SetActive(true);
        ammoText.gameObject.SetActive(false);
        levelText.gameObject.SetActive(false);
        shotgun.gameObject.SetActive(false);
        bow.gameObject.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);

    }

    // Restarts the game
    public void RestartGame() {
        Destroy(player.gameObject);
        SceneManager.LoadScene("GrassLvl1");
        restartButton.gameObject.SetActive(false);
        gameoverText.gameObject.SetActive(false);
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
        GameObject a = Instantiate(enemy[index], GenerateSpawnPos(), enemy[index].transform.rotation);
        a.GetComponent<Enemy>().source[Random.Range(0,3)].Play();

    }

    private Vector3 GenerateSpawnPos() {
        Collider2D hit;
        Vector3 location;
        do{
            location = player.transform.position + (new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f,1f), 0f).normalized) * Random.Range(4f, 8f);
            hit = Physics2D.OverlapCircle(location, 1f);
        } while(hit); //forces re-roll of location if would spawn zombie in collision
        
        return location;

        
        
        /*
        float spawnPosX = Random.Range(-26, 17);
        float spawnPosY = Random.Range(-7, 30);
        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, 0);
        return randomPos;
        */
    }

    public void UpdateAmmo(int ammo) {
        if (ammo == -1){
            ammoText.text = "Reloading...";
            return;
        }
        if (ammo == -2){
            ammoText.text = "Ammo: ∞";
            return;
        }
        ammoText.text = "Ammo: " + ammo;
    }

    public void UpdateHealth(float health) {
        if (health <= 0){
            healthBar.value = 0f;
            return;
        }
        healthBar.value = health;
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
