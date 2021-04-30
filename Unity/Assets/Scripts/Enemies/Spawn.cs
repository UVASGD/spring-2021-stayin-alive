using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] enemy;
    public float delay = 5;
    public float spawnRate = 1;
    public GameManager gm;
    
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gm.isActive) {
            SpawnWave();
        }
    }

    private void SpawnWave() {
        // for (int i = 0; i < numOfEnemies; i++) {
            int index = Random.Range(0, enemy.Length);
            Instantiate(enemy[index], GenerateSpawnPos(), enemy[index].transform.rotation);
        // }
    }

    private Vector3 GenerateSpawnPos() {
        float spawnPosX = Random.Range(-26, 17);
        float spawnPosY = Random.Range(-7, 30);
        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY);
        return randomPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.isActive) {
            InvokeRepeating("SpawnWave", delay, spawnRate);
        }
    }
}
