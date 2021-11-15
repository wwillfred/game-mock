using UnityEngine;

[CreateAssetMenu(menuName = "Dialog/DialogObject")] //allows us to create DialogObjects from within the Unity editor

public class DialogObject : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialog; //an array of strings that can be set from within the Unity editor
    [SerializeField] private Response[] responses; //an array of responses

    public string[] Dialog => dialog; //we don't want anything external to be able to write to the dialog array, only to read from it

    public Response[] Responses => responses; //get method for Response array
}
