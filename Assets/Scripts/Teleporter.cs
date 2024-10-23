using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MapInteractable
{

    /** References **/
    [SerializeField] private Transform destination;
    [SerializeField] private Dialogue onTriggerDialogue;
    

    /** Variables **/
    private bool dialogueTriggered = false;
    [SerializeField] private bool triggerDialogueOnce = true;
    [SerializeField] private float dialogueDelay = 0f;
    [SerializeField] private int musicID;
    [SerializeField] private int ambientID;
    [SerializeField] private int sfxID;

    [SerializeField] private bool switchMusic = false;
    [SerializeField] private bool switchAmbient = false;
    [SerializeField] private bool playSFX = false;

    protected override void Interact()
    {
        FindObjectOfType<Player>().Teleport(destination);
        if(playSFX) PlaySound();
        if(onTriggerDialogue != null && !dialogueTriggered) Invoke("TriggerDialogue", dialogueDelay);
        SwitchTracks();
    }

    private void PlaySound()
    {
        FindObjectOfType<AudioManager>().PlaySFX(sfxID);
    }

    private void SwitchTracks()
    {
        if(switchMusic) FindObjectOfType<AudioManager>().ChangeMusic(musicID);
        if(switchAmbient) FindObjectOfType<AudioManager>().ChangeAmbient(ambientID);
    }

    private void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartThought(onTriggerDialogue);

        if(triggerDialogueOnce) dialogueTriggered = true;
    }


}
