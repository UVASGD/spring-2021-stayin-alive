using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 movement;
    public Vector2 aim;
    public bool fire;
    public GameManager gm;

    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gm.isActive) {
            movement = new Vector2(0f, 0f);
            aim = new Vector2(1f, 0f);
            fire = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.isActive) {
            movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            aim = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            fire = Input.GetMouseButton(0);
        
            playerController.ProcessInput(movement, aim, fire);
        }
    }
}
