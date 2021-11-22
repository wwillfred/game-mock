using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

//this class is attached to the game's Canvas (as is the DialogUI - so they can reference each other)
public class ResponseHandler : MonoBehaviour
{
    //we'll set each of these in the Unity editor
    [SerializeField] private RectTransform responseBox; //so we can activate and deactivate all the response-related objects
    [SerializeField] private RectTransform responseButtonTemplate; //we will disable this object upon start() and never reactivate it, but we will also Instantiate one or more of these when the ShowResponses() method is called
    [SerializeField] private RectTransform responseContainer; //when we instantiate new responseButtonTemplates, we need to add them to the responseContainer

    private DialogUI dialogUI; //the manager for all dialog functionality

    private List<GameObject> tempResponseButtons = new List<GameObject>(); //we will add to this list in the ShowResponse() method so that we can destroy each one (in the OnPickedResponse() method) once the user has selected one

    private void Start()
    {
        dialogUI = GetComponent<DialogUI>(); //both the ResponseHandler and the DailogUI scripts are attached to the same object in Unity, so they can "GetComponent" each other

        responseBox.gameObject.SetActive(false);
        responseButtonTemplate.gameObject.SetActive(false); //we need this template so we can clone it, but we don't want the template visible to player
    }

    //DialogUI calls this when it gets to the end of a DialogObject that has responses - we need this method to create the responseButtons and associate the right Response object with the right button
    public void ShowResponses(Response[] responses)
    {
        float responseBoxHeight = 0; //we will iteratively increment this as we step through the responses[] array

        foreach (Response response in responses)
        {
            GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, responseContainer); //create a new responseButton
            responseButton.gameObject.SetActive(true); //activate said button
            responseButton.GetComponent<TMP_Text>().text = response.ResponseText; //set the responseButton's text to the string of the Response object
            responseButton.GetComponent<Button>().onClick.AddListener(() => OnPickedResponse(response)); //set up the Unity system to call the OnPickedResponse() method when the user clicks botton

            tempResponseButtons.Add(responseButton); //so we can destroy each one in the OnPickedResponse() method once user has picked a response

            responseBoxHeight += responseButtonTemplate.sizeDelta.y; //we incrementally set the size of the responseBox before we activate it
           
        }
        responseBox.sizeDelta = new Vector2(responseBox.sizeDelta.x, responseBoxHeight);
        responseBox.gameObject.SetActive(true); //now we can see it!
    }

    //the Unity system calls this when the user clicks a response (via AddListener() ) - we need this method so we can deactivate the responseBox and destroy each responseButton and clear the tempResponseButtons list and display the dialogObject owned by the Response instance chosen by the user
    private void OnPickedResponse(Response response)
    {
        responseBox.gameObject.SetActive(false);

        foreach (GameObject button in tempResponseButtons)
        {
            Destroy(button);
        }
        tempResponseButtons.Clear();

        dialogUI.ShowDialog(response.DialogObject);
    }
    
}
