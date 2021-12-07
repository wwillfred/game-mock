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
        Debug.Log("Player has left the bush");
        Collider2D other = collision.collider;
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerController player)) //does this have the Player tag and the PlayerController script attached?
        {
            if (player.Interactable is BushController bushController && bushController == this) //double check that the player was actually interacting with a bushController and it was this
            {
                player.Interactable = null;
            }
            else Debug.LogWarning("attempted to set player.Interactable to null, but player wasn't interacting with bush");
        }
    }

    //the playerController calls this when the user presses an interact key
    public void Interact(PlayerController playerController)
    {
        if (!playerController.canClearBush())
        {
            playerController.DialogUI.ShowDialog(dialog_playerCannotClear);
        }
        else if (playerController.canClearBush())
        {

            //the bush is currently made of child gameObjects, so we need to destroy those
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            Destroy(this.gameObject); //and finally we need to destroy the bush
                                      //note: no need to call the "player.Interactable = null" here, because as soon as the bush is destroyed, this "OnCollisionExit2D" is called

            playerController.DialogUI.ShowDialog(dialog_playerCanClear); //show the dialog to explain that the player just cleared the bush

        }
    }
}
