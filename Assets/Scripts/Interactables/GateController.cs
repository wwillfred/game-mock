using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : DialogActivator
{
    [SerializeField] private DialogObject dialog_playerDoesNotHaveKey; //when player interacts with gate without possession of key

    public bool gateOpen = false; //not sure if I need this variable

    public float openHeight = 4.5f;
    public float duration = 1;

    Vector3 closePosition;

    public void Start()
    {
        closePosition = transform.position;
    }

    public override void Interact(PlayerController playerController)
    {
        if (!gateOpen)
        {
            if (!playerController.hasQuarryGateKey)
            {
                playerController.DialogUI.ShowDialog(dialog_playerDoesNotHaveKey); //explain to player the gate is locked
            }
            else
            {
                Vector3 openPosition = closePosition + Vector3.up * openHeight;
                StartCoroutine(MoveGate(openPosition));
            }
        }
    }

    //moves gate to specified target position
    IEnumerator MoveGate(Vector3 targetPosition)
    {
        float timeElapsed = 0;
        Vector3 startPosition = transform.position;

        while (timeElapsed < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }

}
