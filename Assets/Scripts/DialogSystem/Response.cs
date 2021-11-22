using UnityEngine;

[System.Serializable] //allows other objects to have their Responses editable in the Unity editor

//Class for storing dialog responses
public class Response
{
    [SerializeField] private string responseText; //the text this object was made to store
    [SerializeField] private DialogObject dialogObject; //the dialog to be shown if the user selects this Response

    public string ResponseText => responseText;

    public DialogObject DialogObject => dialogObject;
}
