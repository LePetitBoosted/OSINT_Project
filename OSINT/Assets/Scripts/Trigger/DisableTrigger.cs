using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class DisableTrigger : TriggerBase
{
	public GameObject objectToDisable;

	override public void Trigger()
	{
		objectToDisable.SetActive(false);
	}
}
