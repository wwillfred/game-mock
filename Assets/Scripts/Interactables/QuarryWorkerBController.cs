using UnityEngine;

public class QuarryWorkerBController : DialogActivator
{
    [SerializeField] private DialogObject dialog_InitialDialog;

    public override void Interact(PlayerController playerController)
    {
        playerController.DialogUI.ShowDialog(dialog_InitialDialog);

        playerController.hasSpokenToQuarryWorkerB = true;
    }
}
