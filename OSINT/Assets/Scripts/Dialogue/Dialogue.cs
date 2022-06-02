using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class Dialogue
{
	public string name;

	[System.Serializable]
	public struct Line 
	{
		public enum TypeOfLine { Sentence, Answer }

		[EnumToggleButtons]
		public TypeOfLine type;

		[ShowIf("type", TypeOfLine.Sentence)]
		[TextArea(3, 10)]
		public string sentence;

		[ShowIf("type", TypeOfLine.Answer)]
		public string[] correctAnswers;
	}

	public Line[] lines;
}