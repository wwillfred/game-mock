using UnityEngine;

public class QuarryWorkerAController : DialogActivator
{
    [SerializeField] private DialogObject dialog_InitialDialog;
    [SerializeField] private DialogObject dialog_ReturnToQuarry;

    [SerializeField] private GameObject truck;

    public Vector2 workingPosition;
    public float timeToWorkingPositionX = 10;
    public float timeToWorkingPositionY = 1;

    public override void Interact(PlayerController playerController)
    {
        if (!playerController.hasSpokenToQuarryWorkerB)
        {
            playerController.DialogUI.ShowDialog(dialog_InitialDialog);
        }
        else
        {
            
            playerController.DialogUI.ShowDialog(dialog_ReturnToQuarry);

            //Vector3 workingPosition = transform.position + Vector3.right * workingTranslateX;
            GoBackToWork();            
        }
    }

    private void GoBackToWork()
    {
        Vector3 targetPosition = new Vector3(workingPosition.x, transform.position.y, transform.position.z);
        StartCoroutine(Move(targetPosition, timeToWorkingPositionX));

        targetPosition.y = workingPosition.y;
        StartCoroutine(Move(targetPosition, timeToWorkingPositionY));

    }
}
