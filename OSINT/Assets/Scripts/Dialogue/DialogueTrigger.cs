using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : TriggerBase
{
	public Dialogue dialogue;

	override public void Trigger()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}
}