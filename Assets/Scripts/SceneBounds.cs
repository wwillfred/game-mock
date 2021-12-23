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
            float playerRHEdge = other.gameObject.transform.position.x + other.GetComponent<BoxCollider2D>().size.x / 2;
            float playerTopEdge = other.gameObject.transform.position.y + other.GetComponent<BoxCollider2D>().size.y / 2;
            float playerLHEdge = other.gameObject.transform.position.x - other.GetComponent<BoxCollider2D>().size.x / 2;
            float playerBottomEdge = other.gameObject.transform.position.y - other.GetComponent<BoxCollider2D>().size.y / 2;

            float sceneRHEdge = gameObject.transform.position.x + boxCollider.size.x / 2;
            float sceneTopEdge = gameObject.transform.position.y + boxCollider.size.y / 2;
            float sceneLHEdge = gameObject.transform.position.x - boxCollider.size.x / 2;
            float sceneBottomEdge = gameObject.transform.position.y - boxCollider.size.y / 2;

            //Vector2 playerPosition = other.gameObject.transform.position;
            //Vector2 playerColliderSize = other.GetComponent<BoxCollider2D>().size;

            //Vector2 cameraPosition = gameObject.transform.position;
            //Vector2 cameraSize = boxCollider.size;

            Debug.Log("Player is triggering scene bounds. Player edges are: " + playerRHEdge + ", " + playerBottomEdge + ", " + playerLHEdge + ", " + playerTopEdge + ". Scene edges are: " + sceneRHEdge + ", " + sceneBottomEdge + ", " + sceneLHEdge + ", " + sceneTopEdge);

            //is RH edge of player equal to or more than RH edge of scene, and is player between top and bottom edges of scene?
            if (playerRHEdge >= sceneRHEdge && playerTopEdge < sceneTopEdge && playerBottomEdge > sceneBottomEdge)
            {
                Debug.Log("Player is leaving RH edge of scene. Player RH edge: " + playerRHEdge + ", scene RH edge: " + sceneRHEdge + ". Player top edge: " + playerTopEdge + ", scene top edge: " + sceneTopEdge + ". Player bottom edge: " + playerBottomEdge + ", scene bottom edge: " + sceneBottomEdge);
            }
            //is top edge of player equal to or more than top edge of scene, and is player between LH and RH edges of scene?
            else if (playerTopEdge >= sceneTopEdge && playerRHEdge < sceneRHEdge && playerLHEdge > sceneLHEdge)
            {
                Debug.Log("Player is leaving top edge of scene. Player top edge: " + playerTopEdge + ", scene top edge: " + sceneTopEdge + ". Player LH edge: " + playerLHEdge + ", scene LH edge: " + sceneLHEdge + ". Player RH edge: " + playerRHEdge + ", scene RH edge: " + sceneRHEdge);
            }
            //is LH edge of player equal to or less than LH edge of scene, and is player between top and bottom edges of scene?
            else if (playerLHEdge <= sceneLHEdge && playerTopEdge < sceneTopEdge && playerBottomEdge > sceneBottomEdge)
            {
                Debug.Log("Player is leaving LH edge of scene. Player LH edge: " + playerLHEdge + ", scene LH edge: " + sceneLHEdge + ". Player top edge: " + playerTopEdge + ", scene top edge: " + sceneTopEdge + ". Player bottom edge: " + playerBottomEdge + ", scene bottom edge: " + sceneBottomEdge);
            }
            else if (playerBottomEdge <= sceneBottomEdge && playerLHEdge > sceneLHEdge && playerRHEdge < sceneRHEdge)
            {
                Debug.Log("Player is leaving bottom edge of scene. Player bottom edge: " + playerBottomEdge + ", scene bottom edge: " + sceneBottomEdge + ". Player LH edge: " + playerLHEdge + ", scene LH edge: " + sceneLHEdge + ". Player RH edge: " + playerRHEdge + ", scene RH edge: " + sceneRHEdge);
            }

        }

    }
}
