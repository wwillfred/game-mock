using System.Collections;
using UnityEngine;

//script to attach to NPC's and other objects in game that generate dialog when the user interacts
//note: this script also includes a movement coroutine, so that inherited classes don't need to define this coroutine every class

public class DialogActivator : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogObject dialogObject; //the dialogObject that the DialogUI system will display when the player interacts with this

    public Vector2 translateDelta; //the delta used in the Move() coroutine
    public float duration; //the specified time

    //when a Collider2D (presumably the player) triggers this object, tell them that this is what they are interacting with
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D other = collision.collider;
        Debug.Log("player is colliding with DialogActivator!");
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerController player)) //does this have the Player tag and the PlayerController script attached?
        {
            player.Interactable = this; //tell the playerController that this is the object they're interacting with
        }
    }

    //when a Collider2D (presumably the player) leaves, tell them that they're not interacting with anything
    private void OnCollisionExit2D(Collision2D collision)
    {
        Collider2D other = collision.collider;
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerController player)) //does this have the Player tag and the PlayerController script attached?
        {
            if (player.Interactable is DialogActivator dialogActivator && dialogActivator == this) //double check that the player was actually interacting with something and that it was this
            {
                player.Interactable = null;
                Debug.Log("Player was interacting with dialogActivator but isn't now");
            }
        }
    }

    //the playerController calls this when the user presses an interact key
    public virtual void Interact(PlayerController playerController)
    {
        playerController.DialogUI.ShowDialog(dialogObject);
    }


    protected IEnumerator Move(Vector3 targetPosition, float duration)
    {
        float timeElapsed = 0;
        Vector3 startPosition = transform.position;

        while (timeElapsed < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;

    }
    
}
