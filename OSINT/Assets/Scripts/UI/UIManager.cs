using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject[] canvas;

    public GameObject interactionText;

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
}
