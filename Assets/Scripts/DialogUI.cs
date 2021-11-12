using System.Collections;
using UnityEngine;
using TMPro;

public class DialogUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel; // pointer to a text label that will be specified within the Unity editor. we will pass this label to the typewriterEffect so it knows where to write to
    [SerializeField] private DialogObject testDialog;

    private TypewriterEffect typewriterEffect; // pointer to the class that produces the typewriter effect 

    //called before first frame
    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>(); // set the pointer to the actual class
        ShowDialog(testDialog); // sends the testDialog be typewritered
    }

    //public method for specifying a dialogObject (with a String array) and for "typewritering" the strings
    public void ShowDialog(DialogObject dialogObject)
    {
        StartCoroutine(StepThroughDialog(dialogObject)); // calls the private method for typewritering the dialog
    }

    // private method for typewritering the dialog
    private IEnumerator StepThroughDialog(DialogObject dialogObject)
    {
        foreach (string dialog in dialogObject.Dialog) //do the following for every string in the dialogObject that was just passed to us
        {
            yield return typewriterEffect.Run(dialog, textLabel); // tell the typewriterEffect to do its thing with this string with the text label that we specified in Unity editor
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }
    }
}

