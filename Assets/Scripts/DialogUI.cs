using System.Collections;
using UnityEngine;
using TMPro;

public class DialogUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private TMP_Text textLabel; // pointer to a text label that will be specified within the Unity editor. we will pass this label to the typewriterEffect so it knows where to write to
    [SerializeField] private DialogObject testDialog;

    private ResponseHandler responseHandler;
    private TypewriterEffect typewriterEffect; // pointer to the class that produces the typewriter effect 

    //called before first frame
    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>(); // set the pointer to the TypewriterEffect object
        responseHandler = GetComponent<ResponseHandler>(); // point to the ResponseHandler object
        CloseDialogBox(); // make sure the dialog box is not showing at beginning of game
        ShowDialog(testDialog); // sends the testDialog be typewritered
    }

    //public method for specifying a dialogObject (with a String array) and for "typewritering" the strings
    public void ShowDialog(DialogObject dialogObject)
    {
        dialogBox.SetActive(true); // make the dialog box appear!
        StartCoroutine(StepThroughDialog(dialogObject)); // calls the private method for typewritering the dialog
    }

    // private method for typewritering the dialog
    private IEnumerator StepThroughDialog(DialogObject dialogObject)
    {
        for (int i = 0; i < dialogObject.Dialog.Length; i++)
        {
            string dialog = dialogObject.Dialog[i];
            yield return typewriterEffect.Run(dialog, textLabel); // tell the typewriterEffect to do its thing with this string with the text label that we specified in Unity editor

            if (i == dialogObject.Dialog.Length - 1 && dialogObject.HasResponses) break;

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        if (dialogObject.HasResponses)
        {
            responseHandler.ShowResponses(dialogObject.Responses);
        }
        else
        {
            CloseDialogBox();
        }
    }

    // private method for closing the dialog box
    private void CloseDialogBox()
    {
        dialogBox.SetActive(false); // make dialog box invisible to user
        textLabel.text = string.Empty; // make sure there's no residual text hidden in the box
    }
}

