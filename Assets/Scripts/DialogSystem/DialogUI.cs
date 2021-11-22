using System.Collections;
using UnityEngine;
using TMPro;

public class DialogUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private TMP_Text textLabel; // pointer to a text label that will be specified within the Unity editor. we will pass this label to the typewriterEffect so it knows where to write to

    public bool IsOpen { get; private set;} //outsiders can only check whether dialog is open

    private ResponseHandler responseHandler;
    private TypewriterEffect typewriterEffect; // pointer to the class that produces the typewriter effect 

    //called before first frame
    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>(); // set the pointer to the TypewriterEffect object
        responseHandler = GetComponent<ResponseHandler>(); // point to the ResponseHandler object
        CloseDialogBox(); // make sure the dialog box is not showing at beginning of game
    }

    //public method for specifying a dialogObject (with a String array) and for "typewritering" the strings
    public void ShowDialog(DialogObject dialogObject)
    {
        IsOpen = true; //dialog is open!
        dialogBox.SetActive(true); // make the dialog box appear!
        StartCoroutine(StepThroughDialog(dialogObject)); // calls the private method for typewritering the dialog
    }

    // private method for typewritering the dialog
    private IEnumerator StepThroughDialog(DialogObject dialogObject)
    {
        for (int i = 0; i < dialogObject.Dialog.Length; i++) //for every String in the array...
        {
            string dialog = dialogObject.Dialog[i]; //create a reference to the i'th String
            yield return typewriterEffect.Run(dialog, textLabel); // tell the typewriterEffect to do its thing with this string with the text label that we specified in Unity editor

            if (i == dialogObject.Dialog.Length - 1 && dialogObject.HasResponses) break; //if we've iterated to the end of the String array and we have responses to offer the player, we should not wait for input to close the dialog box

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space)); //otherwise, after the typewriter effect has finished the string, wait for input before starting the next one
        }

        //if the dialog object has responses, show them; otherwise, close the dialog box
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
        IsOpen = false; //dialog is not open!
        dialogBox.SetActive(false); // make dialog box invisible to user
        textLabel.text = string.Empty; // make sure there's no residual text hidden in the box
    }
}

