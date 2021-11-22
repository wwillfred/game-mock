//interface that the DialogActivator class implements - we can thus attach the DialogActivator class to any object the player could interact with
public interface IInteractable
{
    void Interact(PlayerController playerController);
}
