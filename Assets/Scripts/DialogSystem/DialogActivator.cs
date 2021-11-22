using UnityEngine;

//script to attach to NPC's and other objects in game that generate dialog when the user interacts
public class DialogActivator : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogObject dialogObject; //the dialogObject that the DialogUI system will display when the player interacts with this

    //when a Collider2D (presumably the player) triggers this object, tell them that this is what they are interacting with
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerController player)) //does this have the Player tag and the PlayerController script attached?
        {
            player.Interactable = this; //tell the playerController that this is the object they're interacting with
        }
    }

    //when a Collider2D (presumably the player) leaves, tell them that they're not interacting with anything
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerController player)) //does this have the Player tag and the PlayerController script attached?
        {
            if (player.Interactable is DialogActivator dialogActivator && dialogActivator == this) //double check that the player was actually interacting with something and that it was this
            {
                player.Interactable = null;
            }
        }
    }

    //the playerController calls this when the user presses an interact key
    public void Interact(PlayerController playerController)
    {
        playerController.DialogUI.ShowDialog(dialogObject);
    }
}
