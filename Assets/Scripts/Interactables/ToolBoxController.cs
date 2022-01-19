using UnityEngine;

public class ToolBoxController : DialogActivator
{
    [SerializeField] private DialogObject dialog_playerFindsKey; //dialog to show when player opens toolbox and finds gate key
    [SerializeField] private DialogObject dialog_playerFindsNothing; //dialog to show when player interacts with toolbox but has already obtained gate key

    public bool hasBeenOpenedByPlayer = false; //how the toolbox knows whether it has been opened by the player yet

    public override void Interact(PlayerController playerController)
    {
        if (!hasBeenOpenedByPlayer)
        {
            if (playerController.hasQuarryGateKey) Debug.LogWarning("Warning: toolbox has not been opened, but player somehow already has gate key", this);

            playerController.hasQuarryGateKey = true; //tell the player they now have the gate key
            playerController.DialogUI.ShowDialog(dialog_playerFindsKey); //tell the dialog system to explain to player they found key in toolbox
            hasBeenOpenedByPlayer = true;
        }
        else
        {
            if (!playerController.hasQuarryGateKey) Debug.LogWarning("Warning: toolbox has already been opened, but player somehow does NOT have gate key", this);
            playerController.DialogUI.ShowDialog(dialog_playerFindsNothing); //tell player nothing else in toolbox

        }
    }

}
