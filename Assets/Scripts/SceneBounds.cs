using UnityEngine;

public class SceneBounds : MonoBehaviour
{
    Rigidbody2D body;
    BoxCollider2D collider;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerController player)) //does this have the Player tag and the PlayerController script attached?
        {
            Vector2 playerPosition = other.gameObject.transform.position;
            Vector2 cameraPosition = gameObject.transform.position;
            Vector2 cameraSize = collider.size;

            Debug.Log("Player is triggering scene bounds. Player position is: " + playerPosition + ". Camera position is: " + cameraPosition);

            if (playerPosition.x > cameraPosition.x && playerPosition.y < (cameraPosition.y + (cameraSize.y /2)) && playerPosition.y > (cameraPosition.y - (cameraSize.y /2)))
            {
                Debug.Log("Player is leaving right side of screen");
            }

        }

    }
}
