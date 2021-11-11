using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    // public method for specifying a textLabel object and the String to type to it
    public void Run(string textToType, TMP_Text textLabel)
    {
        StartCoroutine(TypeText(textToType, textLabel));
    }

    //private method that "typewriter-s" the given text to the given textLabel
    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {
        float t = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length)
        {
            t += Time.deltaTime; // t equals how many seconds have passed since we started this coroutine
            charIndex = Mathf.FloorToInt(t); // charIndex equals largest integer equal to or less than the number of seconds that have passed since we started this coroutine
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length); // clamp CharIndex between 0 and the length of the string we are typing

            textLabel.text = textToType.Substring(0, charIndex); // set the text label to the number of characters of string equal to the number of seconds that have passed since we started the coroutine

            yield return null;
        }

        textLabel.text = textToType; // just to make sure that at the end of this coroutine, the text label equals the entire string we wanted to type
    }
}
