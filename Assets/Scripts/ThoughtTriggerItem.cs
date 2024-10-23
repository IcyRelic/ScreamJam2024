using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtTriggerItem : Interactable
{
    /** References **/
    [SerializeField] private Dialogue thought;

    protected override void Interact()
    {
        FindObjectOfType<DialogueManager>().StartThought(thought);

        DestroyInteractable();
    }
}
