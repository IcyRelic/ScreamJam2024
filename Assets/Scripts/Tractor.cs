using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tractor : MapInteractable
{
    /** References **/
    [SerializeField] private Dialogue thought;

    protected override void Interact()
    {
        ProgressionManager.Instance.Oil = true;
        FindObjectOfType<DialogueManager>().StartThought(thought);
        DestroyInteractable();
    }

}
