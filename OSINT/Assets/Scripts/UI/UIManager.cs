using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject[] canvas;

    public GameObject interactionText;

    public GameObject sentenceParent;
    public TMP_Text speakerText;
    public TMP_Text dialogueText;

    public GameObject answerParent;
    public TMP_Text questionText;
    public TMP_InputField asnwerInputField;

    public void DisplayOnlyCanvas(GameObject canvasToDisplay) 
    {
        foreach (GameObject curCanvas in canvas) 
        {
            curCanvas.SetActive(false);
        }

        canvasToDisplay.SetActive(true);
    }

    public void DisplayInteractionText(string textToDisplay = null) 
    {
        if(textToDisplay != null) 
        {
            interactionText.GetComponent<TMP_Text>().text = textToDisplay;
        }

        interactionText.SetActive(true);
    }

    public void UndisplayInteractionText() 
    {
        interactionText.SetActive(false);
    }

    public void UpdateSpeakerName(string speakerName) 
    {
        speakerText.text = speakerName;
    }

    public void DisplaySentence(string sentenceToDisplay)
    {
        if (!sentenceParent.activeInHierarchy)
        {
            sentenceParent.SetActive(true);
            answerParent.SetActive(false);
        }

        StartCoroutine(TypeSentence(sentenceToDisplay));
    }

    public IEnumerator TypeSentence(string sentenceToType) 
    {
        dialogueText.text = "";
        foreach (char letter in sentenceToType.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void DisplayAnswer(string questionToDisplay)
    {
        if (!answerParent.activeInHierarchy)
        {
            answerParent.SetActive(true);
            sentenceParent.SetActive(false);
        }

        questionText.text = questionToDisplay;
        asnwerInputField.text = "";

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
