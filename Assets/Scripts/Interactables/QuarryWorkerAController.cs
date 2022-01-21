using UnityEngine;

public class QuarryWorkerAController : DialogActivator
{
    [SerializeField] private DialogObject dialog_InitialDialog;
    [SerializeField] private DialogObject dialog_ReturnToQuarry;

    [SerializeField] private GameObject truck;

    public float workingTranslateX = 20;
    public float timeToWorkingTranslateX = 10;

    public override void Interact(PlayerController playerController)
    {
        if (!playerController.hasSpokenToQuarryWorkerB)
        {
            playerController.DialogUI.ShowDialog(dialog_InitialDialog);
        }
        else
        {
            /*
            playerController.DialogUI.ShowDialog(dialog_ReturnToQuarry);

            Vector3 workingPosition = transform.position + Vector3.right * workingTranslateX;
            StartCoroutine(move(workingPosition));

            move();
            */
        }
    }

    private void move()
    {

    }
}
