using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 movement;
    public Vector2 aim;
    public bool fire;
    public bool reload;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        movement = new Vector2(0f, 0f);
        aim = new Vector2(1f, 0f);
        fire = false;
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        aim = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        fire = Input.GetMouseButton(0);
        reload = Input.GetKeyDown("r");
        playerController.ProcessInput(movement, aim, fire, reload);
    }
}
