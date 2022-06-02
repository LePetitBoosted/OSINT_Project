using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class Dialogue
{
	public string name;

	[System.Serializable]
	public class Line
	{
		public enum TypeOfLine { Sentence, Answer, Trigger }

		[EnumToggleButtons]
		public TypeOfLine type;

		[ShowIf("type", TypeOfLine.Sentence)]
		[TextArea(3, 10)]
		public string sentence;

		[ShowIf("type", TypeOfLine.Answer)]
		public string question;
		[ShowIf("type", TypeOfLine.Answer)]
		public string[] correctAnswers;
		[ShowIf("type", TypeOfLine.Answer)]
		public TriggerBase correctTrigger;
		[ShowIf("type", TypeOfLine.Answer)]
		public TriggerBase wrongTrigger;

		[ShowIf("type", TypeOfLine.Trigger)]
		public TriggerBase[] triggers;
	}

	public Line[] lines;
}