using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
	public GameObject normalCanvas;
	public GameObject dialogueCanvas;

	public TMP_Text speakerText;
	public TMP_Text dialogueText;
	
	UIManager UIManager;

	bool inDialogue;

	//public Animator animator;

	private Queue<string> sentences;

	private void Awake()
	{
		UIManager = FindObjectOfType<UIManager>();
	}

	void Start()
	{
		sentences = new Queue<string>();
	}

	private void Update()
	{
		if(inDialogue && Input.GetMouseButtonDown(0)) 
		{
			DisplayNextSentence();
		}
	}

	public void StartDialogue(Dialogue dialogue)
	{
		inDialogue = true;

		UIManager.DisplayOnlyCanvas(dialogueCanvas);

		//animator.SetBool("IsOpen", true);

		speakerText.text = dialogue.name;

		sentences.Clear();

		foreach (Dialogue.Line line in dialogue.lines)
		{
			sentences.Enqueue(line.sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
		//animator.SetBool("IsOpen", false);

		UIManager.DisplayOnlyCanvas(normalCanvas);

		inDialogue = false;
	}

}