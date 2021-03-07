using UnityEngine;

public class Interactable : MonoBehaviour {
    public Vector2 colliderSize = Vector2.one;
    public bool drawInteractionZone;    // Draw zone for debugging

    private BoxCollider2D interactionZone;    // Interaction zone collider

    private void Start() {
        interactionZone = gameObject.AddComponent<BoxCollider2D>();
        interactionZone.size = colliderSize;
        interactionZone.isTrigger = true;
    }

    // for debugging: draws interactable zone
    private void OnDrawGizmosSelected() {
        if (drawInteractionZone) {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, new Vector3(colliderSize.x * transform.localScale.x, colliderSize.y * transform.localScale.y));
        }
    }

    // Base interact function, meant to be overwritten
    public virtual void Interact() {}
}
