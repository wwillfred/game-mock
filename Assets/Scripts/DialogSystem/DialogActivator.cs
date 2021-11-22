using UnityEngine;

//script to attach to objects in game that generate dialog when the user interacts
public class DialogActivator : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogObject dialogObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerController player)) //does this have the Player tag and the PlayerController script attached?
        {
            player.Interactable = this;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerController player)) //does this have the Player tag and the PlayerController script attached?
        {
            if (player.Interactable is DialogActivator dialogActivator && dialogActivator == this)
            {
                player.Interactable = null;
            }
        }
    }

    public void Interact(PlayerController playerController)
    {
        playerController.DialogUI.ShowDialog(dialogObject);
    }
}
