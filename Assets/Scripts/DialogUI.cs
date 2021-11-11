using UnityEngine;
using TMPro;

public class DialogUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel; // a pointer to a text label that will be specified within the Unity editor

    private void Start()
    {
        GetComponent<TypewriterEffect>().Run("This is a bit of text\nHello!", textLabel);
    }
}

