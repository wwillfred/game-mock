using System.Collections;
using UnityEngine;

public class QuarryWorkerAController : DialogActivator
{
    [SerializeField] private DialogObject dialog_InitialDialog;
    [SerializeField] private DialogObject dialog_ReturnToQuarry;

    [SerializeField] private GameObject truck;
    public Vector2 truckWorkingPosition;

    [SerializeField] private GameObject quarryWorkerB;
    public Vector2 quarryWorkerBWorkingPosition;
    public Vector2 workingPosition;

    public float offScreenPositionX;
    public float timeToOffScreenPositionX = 1.5f;
    //public float timeToWorkingPositionY = 1;

    public override void Interact(PlayerController playerController)
    {
        if (!playerController.hasSpokenToQuarryWorkerB)
        {
            playerController.DialogUI.ShowDialog(dialog_InitialDialog);
        }
        else
        {
            
            //playerController.DialogUI.ShowDialog(dialog_ReturnToQuarry);

            StartCoroutine(GoBackToWork(playerController));            
        }
    }

    private IEnumerator GoBackToWork(PlayerController playerController)
    {
        yield return playerController.DialogUI.ShowDialog(dialog_ReturnToQuarry);

        playerController.canMove = false;

        GetComponent<BoxCollider2D>().enabled = false; //so the worker can clip through the player
        Vector3 targetPosition = new Vector3(offScreenPositionX, transform.position.y, transform.position.z);
        yield return StartCoroutine(Move(targetPosition, timeToOffScreenPositionX));
        GetComponent<BoxCollider2D>().enabled = true;

        //instantly move the off-screen GameObjects where they need to go
        transform.position = workingPosition;
        truck.transform.position = truckWorkingPosition;
        quarryWorkerB.transform.position = quarryWorkerBWorkingPosition;

        //targetPosition.y = workingPosition.y;
        //StartCoroutine(Move(targetPosition, timeToWorkingPositionY));

        playerController.canMove = true;

    }
}
