using UnityEngine;

[CreateAssetMenu(menuName = "Dialog/DialogObject")] //allows us to create DialogObjects from within the Unity editor

public class DialogObject : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialog; //an array of strings that can be set from within the Unity editor
    [SerializeField] private Response[] responses; //an array of responses

    public string[] Dialog => dialog; //get the Dialog array

    public bool HasResponses => Responses != null && Responses.Length > 0; //DialogUI needs to check whether this DialogObject has responses so it can pass the responses[] array to the ResponseHandler. it's conceivable that we might accidentally create a Responses array with nothing in it, that's why we're checking for length

    public Response[] Responses => responses; //get method for Response array
}
