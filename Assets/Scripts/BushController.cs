using UnityEngine;

public class BushController : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogObject dialog_playerCannotClear; //dialog to show when the player interacts without item needed to clear bush
    [SerializeField] private DialogObject dialog_playerCanClear; //dialog to show when player interacts with the item needed to clear bush

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

    //the playerController calls this when the user presses an interact key
    public void Interact(PlayerController playerController)
    {
        if (!playerController.hasHatchet)
        {
            playerController.DialogUI.ShowDialog(dialog_playerCannotClear);
        }
        else if (playerController.hasHatchet)
        {
            playerController.Interactable = null;

            Destroy(this);

            playerController.DialogUI.ShowDialog(dialog_playerCanClear); //show the dialog to explain that the player just cleared the bush

        }
    }
}
