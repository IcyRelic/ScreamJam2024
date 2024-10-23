using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedTeleporter : MapInteractable
{
    /** References **/
    [SerializeField] private Transform destination;
    [SerializeField] private Dialogue onTriggerLockDialogue;

    public bool Locked => !ProgressionManager.Instance.Key;

    /** Variables **/
    private bool dialogueTriggered = false;

    protected override void Interact()
    {
        if(Locked)
        {
            TriggerDialogue();
            //locked sound
        } else Teleport();

    }

    private void PlaySound()
    {

    }

    private void Teleport()
    {
        FindObjectOfType<Player>().Teleport(destination);
        PlaySound();
    }

    private void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartThought(onTriggerLockDialogue);
    }
}
