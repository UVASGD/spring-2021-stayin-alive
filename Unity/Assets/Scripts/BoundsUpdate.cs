using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsUpdate : MonoBehaviour
{
    private BoxCollider2D bounds;
    private CameraFollow theCamera;

    // Start is called before the first frame update
    void Start()
    {
        bounds = GetComponent<BoxCollider2D>();
        theCamera = FindObjectOfType<CameraFollow>();
        theCamera.SetBounds(bounds);
    }
}
