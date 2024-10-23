using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedTeleporter : MapInteractable
{
    /** References **/
    [SerializeField] private Transform destination;
    [SerializeField] private Dialogue onTriggerLockDialogue;


    [SerializeField] private int musicID;
    [SerializeField] private int ambientID;
    [SerializeField] private bool switchMusic = false;
    [SerializeField] private bool switchAmbient = false;

    /** Variables **/
    private bool dialogueTriggered = false;
    
    public bool Locked => !ProgressionManager.Instance.Key;

    protected override void Interact()
    {
        if(Locked)
        {
            TriggerDialogue();
            //locked sound
        } else Teleport();

    }

    private void SwitchTracks()
    {
        if(switchMusic) FindObjectOfType<AudioManager>().ChangeMusic(musicID);
        if(switchAmbient) FindObjectOfType<AudioManager>().ChangeAmbient(ambientID);
    }

    private void Teleport()
    {
        FindObjectOfType<Player>().Teleport(destination);
        SwitchTracks();
    }

    private void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartThought(onTriggerLockDialogue);
    }
}
