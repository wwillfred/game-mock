using UnityEngine;

public class SceneBounds : MonoBehaviour
{
    Rigidbody2D body;
    BoxCollider2D boxCollider;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerController player)) //does this have the Player tag and the PlayerController script attached?
        {
            Vector2 playerPosition = other.gameObject.transform.position;
            Vector2 playerColliderSize = other.GetComponent<BoxCollider2D>().size;

            Vector2 cameraPosition = gameObject.transform.position;
            Vector2 cameraSize = boxCollider.size;

            Debug.Log("Player is triggering scene bounds. Player position is: " + playerPosition + ". Player size is: " + playerColliderSize + ". Camera position is: " + cameraPosition + ". Camera size is: " + cameraSize);

            //is RH edge of player equal to or more than RH edge of collider, and is player between top and bottom edges of collider?
            if (playerPosition.x + playerColliderSize.x /2 >= cameraPosition.x + cameraSize.x / 2 && playerPosition.y + playerColliderSize.y / 2 < cameraPosition.y + cameraSize.y / 2 && playerPosition.y - playerColliderSize.y /2 > cameraPosition.y - cameraSize.y /2)
            {
                Debug.Log("Player is leaving RH side of screen. Player position is: " + playerPosition + ". Player size is: " + playerColliderSize + ". Camera position is: " + cameraPosition + ". Camera size is: " + cameraSize);
            }
            else if (playerPosition.y + playerColliderSize.y /2 >= cameraPosition.y + cameraSize.y /2 && playerPosition.x + playerColliderSize.x / 2 < cameraPosition.x + cameraSize.x /2 && playerPosition.x - playerColliderSize.x /2 > cameraPosition.x - cameraSize.x / 2)
            {
                Debug.Log("Player has left the top edge of screen. Player position is: " + playerPosition + ". Player size is: " + playerColliderSize + ". Camera position is: " + cameraPosition + ". Camera size is: " + cameraSize);
            }

        }

    }
}
