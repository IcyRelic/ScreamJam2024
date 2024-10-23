using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConditionalThoughtTriggerItem : Interactable
{
    [SerializeField] protected Dialogue[] thoughts;

    protected override void Interact()
    {
        FindObjectOfType<DialogueManager>().StartThought(GetThought());
        DestroyInteractable();
    }

    protected abstract Dialogue GetThought();
}
