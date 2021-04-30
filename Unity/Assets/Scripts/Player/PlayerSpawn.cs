using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, new Vector3(-7, 0, 0), transform.rotation);
        player.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
