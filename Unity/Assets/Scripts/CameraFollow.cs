using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;        // object to follow
    public float smoothingSpeed;    // "lag" between player moving and camera catching up

    public Vector3 offset;          // offset vector from player

    private void Start() {
        // initialize camera position and rotation
        transform.position = target.transform.position + offset;
    }

    private void Update() {
        // move camera with player, interpolating based on amount of smoothing
        Vector3 newPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, newPosition, smoothingSpeed);
    }
}
