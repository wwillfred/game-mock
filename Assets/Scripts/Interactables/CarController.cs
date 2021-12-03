using UnityEngine;

public class CarController : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogObject playerFindsItem; //dialog to show when the player interacts with car and obtains item
    [SerializeField] private DialogObject playerFindsNothing; //dialog to show when player interacts with car and there's nothing to find

    //when a Collider2D (presumably the player) triggers this object, tell them that this is what they are interacting with
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D other = collision.collider;
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerController player)) //does this have the Player tag and the PlayerController script attached?
        {
            player.Interactable = this; //tell the playerController that this is the object they're interacting with

            Debug.Log("Player is colliding with bush!");
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
            }
        }
    }

    //note: assumption here is that the player needs to interact with the car in order to find something that will enable player to clear the bush.
    //the playerController calls this when the user presses an interact key
    public void Interact(PlayerController playerController)
    {
        if (!playerController.canClearBush())
        {
            playerController.findItemInCar(); //tell the playerController to handle finding the item
            playerController.DialogUI.ShowDialog(playerFindsItem); //tell dialog system to explain to player it has found the item
        }
        else if (playerController.canClearBush())
        {
            playerController.DialogUI.ShowDialog(playerFindsNothing); //explain to player there's nothing to find in car
        }
    }
}
