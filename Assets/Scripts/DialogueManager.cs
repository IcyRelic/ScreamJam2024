using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Dictionary<string, Dialogue> dialogues = new Dictionary<string, Dialogue>();

    private void Awake()
    {
        LoadDialogues();

        PlayDialogue("Thought_Hurry");
    }

    private void LoadDialogues() => Resources.LoadAll<Dialogue>("Dialogues").ToList().ForEach(dialogue => dialogues.Add(dialogue.name, dialogue));

    public Dialogue GetDialogue(string dialogueName) => dialogues[dialogueName];

    public void PlayDialogue(string dialogueName)
    {
        Dialogue dialogue = GetDialogue(dialogueName);
        //if its a thought play to players thought bubble

        //if its a story play to the story box
    }
}




/*

Player Thoughts
 - "I should hurry..."
 - "I'm not quite ready to leave yet..."
 - "I should check the other rooms first..."
 - The door is locked...
 - "This might be useful..."
 - "gasps" "What was that?!"
    - "I should be careful..."
    - "I should be cautious..."
 - 
Story

**/