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
            if (Utility.HasPlayerReachedRightEdgeOfCamera(cameraBounds, playerBounds)) MoveCameraRight();

            else if (Utility.HasPlayerReachedLeftEdgeOfCamera(cameraBounds, playerBounds)) MoveCameraLeft();

            else if (Utility.HasPlayerReachedTopEdgeOfCamera(cameraBounds, playerBounds)) MoveCameraUp();

            else if (Utility.HasPlayerReachedBottomEdgeOfCamera(cameraBounds, playerBounds)) MoveCameraDown();

            else Debug.LogWarning("Player is exiting camera but no edge interaction detected");

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
