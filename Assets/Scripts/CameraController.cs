using UnityEngine;

public class CameraController : MonoBehaviour
{
    BoxCollider2D boxCollider;
    private Vector3 camPosition;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        camPosition = gameObject.transform.position;
        Bounds cameraBounds = boxCollider.bounds;
        Bounds playerBounds = other.GetComponent<BoxCollider2D>().bounds;

        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerController player)) //does this have the Player tag and the PlayerController script attached?
        {
            /*
            float playerRHEdge = other.gameObject.transform.position.x + other.GetComponent<BoxCollider2D>().size.x / 2;
            float playerTopEdge = other.gameObject.transform.position.y + other.GetComponent<BoxCollider2D>().size.y / 2;
            float playerLHEdge = other.gameObject.transform.position.x - other.GetComponent<BoxCollider2D>().size.x / 2;
            float playerBottomEdge = other.gameObject.transform.position.y - other.GetComponent<BoxCollider2D>().size.y / 2;

            float sceneRHEdge = gameObject.transform.position.x + boxCollider.size.x / 2;
            float sceneTopEdge = gameObject.transform.position.y + boxCollider.size.y / 2;
            float sceneLHEdge = gameObject.transform.position.x - boxCollider.size.x / 2;
            float sceneBottomEdge = gameObject.transform.position.y - boxCollider.size.y / 2;
            */

            //Debug.Log("Player is triggering scene bounds. Player edges are: " + playerRHEdge + ", " + playerBottomEdge + ", " + playerLHEdge + ", " + playerTopEdge + ". Scene edges are: " + sceneRHEdge + ", " + sceneBottomEdge + ", " + sceneLHEdge + ", " + sceneTopEdge);

            if (Utility.HasPlayerReachedRightEdgeOfCamera(cameraBounds, playerBounds)) MoveCameraRight();

            //is top edge of player equal to or more than top edge of scene, and is player between LH and RH edges of scene?
            else if (Utility.HasPlayerReachedTopEdgeOfCamera(cameraBounds, playerBounds))
            {
                //Debug.Log("Player is leaving top edge of scene. Player top edge: " + playerTopEdge + ", scene top edge: " + sceneTopEdge + ". Player LH edge: " + playerLHEdge + ", scene LH edge: " + sceneLHEdge + ". Player RH edge: " + playerRHEdge + ", scene RH edge: " + sceneRHEdge);
                camPosition.y = camPosition.y + 9;
                gameObject.transform.position = camPosition;
            }
            else if (Utility.HasPlayerReachedLeftEdgeOfCamera(cameraBounds, playerBounds)) MoveCameraLeft();
           
            else if (Utility.HasPlayerReachedBottomEdgeOfCamera(cameraBounds, playerBounds))
            {
                //Debug.Log("Player is leaving bottom edge of scene. Player bottom edge: " + playerBottomEdge + ", scene bottom edge: " + sceneBottomEdge + ". Player LH edge: " + playerLHEdge + ", scene LH edge: " + sceneLHEdge + ". Player RH edge: " + playerRHEdge + ", scene RH edge: " + sceneRHEdge);
                camPosition.y = camPosition.y - 9;
                gameObject.transform.position = camPosition;
            }

        }

    }

    public void MoveCameraRight()
    {
        camPosition.x = camPosition.x + 10;
        gameObject.transform.position = camPosition;
    }

    public void MoveCameraLeft()
    {
        camPosition = gameObject.transform.position;
        camPosition.x = camPosition.x - 10;
        gameObject.transform.position = camPosition;
    }

    public void MoveCameraUp()
    {
        camPosition = gameObject.transform.position;
        camPosition.y = camPosition.y + 9;
        gameObject.transform.position = camPosition;
    }

    public void MoveCameraDown()
    {
        camPosition = gameObject.transform.position;
        camPosition.y = camPosition.y - 9;
        gameObject.transform.position = camPosition;
    }
}
