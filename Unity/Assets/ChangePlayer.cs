using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayer : MonoBehaviour
{
    public SpriteRenderer player_sprite;
    public GameManager gm;
    public Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        player_sprite.gameObject.GetComponent<SpriteRenderer>();
        // ChangeSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeSprite(int i) {
        // Debug.Log("In function");
        if (i == 1) {
            player_sprite.sprite = sprites[0];
            Debug.Log("Change to player 1");
        }
        if (i == 2) {
            player_sprite.sprite = sprites[9];
            Debug.Log("Change to player 2");
        }
    }
}
