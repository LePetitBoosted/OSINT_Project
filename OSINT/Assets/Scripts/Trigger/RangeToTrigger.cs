using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeToTrigger : MonoBehaviour
{
    public bool triggerOnce;
    public bool needInput;

    public float range;
    public Transform transformToCheck;
    public TriggerBase trigger;

    UIManager UIManager;

    bool triggered;

    private void Awake()
    {
        UIManager = FindObjectOfType<UIManager>();
    }

    private void Update()
    {
       if (Vector3.Distance(transform.position, transformToCheck.position) <= range && !triggered) 
       {
            if (!needInput)
            {
                triggered = true;
                trigger.Trigger();
            }
            else if(!UIManager.interactionText.activeInHierarchy) 
            {
                UIManager.DisplayInteractionText();
                if (Input.GetButtonDown("Interact"))
                {
                    Debug.Log("wesh");
                    triggered = true;
                    trigger.Trigger();
                }
            }
       }

       if(!triggerOnce && triggered && Vector3.Distance(transform.position, transformToCheck.position) > range) 
       {
            triggered = false;
       }
    }
}
