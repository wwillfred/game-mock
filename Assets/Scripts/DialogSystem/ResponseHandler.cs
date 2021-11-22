using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class ResponseHandler : MonoBehaviour
{
    [SerializeField] private RectTransform responseBox; //the object that contains the response background and the responses
    [SerializeField] private RectTransform responseButtonTemplate; //the pointer to the button template we set up in the editor
    [SerializeField] private RectTransform responseContainer; //the container for however many responses there will be

    private DialogUI dialogUI; //the manager for all dialog functionality

    private List<GameObject> tempResponseButtons = new List<GameObject>(); //list that will contain each response button we need to instantiate for our dialog

    private void Start()
    {
        dialogUI = GetComponent<DialogUI>(); //both the ResponseHandler and the DailogUI scripts are attached to the same object in Unity, so they can "GetComponent" each other
        responseBox.gameObject.SetActive(false);
        responseButtonTemplate.gameObject.SetActive(false);
    }

    public void ShowResponses(Response[] responses)
    {
        float responseBoxHeight = 0;

        foreach (Response response in responses)
        {
            GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, responseContainer);
            responseButton.gameObject.SetActive(true);
            responseButton.GetComponent<TMP_Text>().text = response.ResponseText;
            responseButton.GetComponent<Button>().onClick.AddListener(() => OnPickedResponse(response));

            tempResponseButtons.Add(responseButton);

            responseBoxHeight += responseButtonTemplate.sizeDelta.y;
           
        }
        responseBox.sizeDelta = new Vector2(responseBox.sizeDelta.x, responseBoxHeight);
        responseBox.gameObject.SetActive(true);
    }

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
