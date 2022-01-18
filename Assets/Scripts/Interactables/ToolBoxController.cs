using UnityEngine;

public class ToolBoxController : DialogActivator
{
    [SerializeField] private DialogObject playerFindsKey; //dialog to show when player opens toolbox and finds gate key
    [SerializeField] private DialogObject playerFindsNothing; //dialog to show when player interacts with toolbox but has already obtained gate key

    public bool hasBeenOpenedByPlayer = false; //how the toolbox knows whether it has been opened by the player yet

    public override void Interact(PlayerController playerController)
    {
        if (!hasBeenOpenedByPlayer)
        {
            playerController.hasQuarryGateKey = true; //tell the player they now have the gate key

        }
    }

}
