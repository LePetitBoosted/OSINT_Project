using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
	public GameObject normalCanvas;
	public GameObject dialogueCanvas;
	
	UIManager UIManager;
	PlayerMovement playerMovement;

	bool inDialogue;
	Dialogue.Line currentLine;

	//public Animator animator;

	private List<Dialogue.Line> lines = new List<Dialogue.Line>();

	private void Awake()
	{
		UIManager = FindObjectOfType<UIManager>();
		playerMovement = FindObjectOfType<PlayerMovement>();
	}

	private void Update()
	{
		if(inDialogue && currentLine.type == Dialogue.Line.TypeOfLine.Sentence && Input.GetMouseButtonDown(0)) 
		{
			DisplayNextSentence();
		}
	}

	public void StartDialogue(Dialogue dialogue)
	{
		inDialogue = true;

		playerMovement.LoseInputs();

		UIManager.DisplayOnlyCanvas(dialogueCanvas);

		//animator.SetBool("IsOpen", true);

		UIManager.UpdateSpeakerName(dialogue.name);

		lines.Clear();

		foreach (Dialogue.Line line in dialogue.lines)
		{
			lines.Add(line);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if (lines.Count == 0)
		{
			EndDialogue();
			return;
		}

		currentLine = lines[0];

		if (currentLine.type == Dialogue.Line.TypeOfLine.Sentence) 
		{
			UIManager.DisplaySentence(currentLine.sentence);
		}

		else if (currentLine.type == Dialogue.Line.TypeOfLine.Answer)
		{
			UIManager.DisplayAnswer(currentLine.question);
		}

		lines.RemoveAt(0);
		UIManager.StopCoroutine(UIManager.TypeSentence(""));
	}

	void EndDialogue()
	{
		//animator.SetBool("IsOpen", false);

		UIManager.DisplayOnlyCanvas(normalCanvas);

		inDialogue = false;

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		playerMovement.RetrieveInputs();
	}

	public void CheckAnswer(string answer) 
	{
		string formatedString = FormatString(answer);
		if (System.Array.Exists(currentLine.correctAnswers, element => element == formatedString))
		{
			currentLine.correctTrigger.Trigger();
		}
		else 
		{
			currentLine.wrongTrigger.Trigger();
		}
	}

	string FormatString(string stringToFormat) 
	{
		string newString = stringToFormat.Replace(" ", "");
		newString = newString.ToLower();

		return newString;
	}
}