using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    /** References **/
    [SerializeField] private TMP_Text dialogueLineText;
    [SerializeField] private TMP_Text characterNameText;
    [SerializeField] private Image characterImage;

    [SerializeField] private TMP_Text thoughtText;
    [SerializeField] private Animator thoughtAnim;

    [SerializeField] private Animator dialogueAnim;

    /** Variables **/
    private Queue<string> lines;
    private Coroutine thoughtCoroutine = null;
    private Coroutine dialogueCoroutine = null;

    private void Awake()
    {
        lines = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueAnim.SetBool("IsOpen", true);
        characterNameText.text = dialogue.characterName;
        characterImage.sprite = dialogue.characterSprite;

        lines.Clear();
        dialogue.lines.ToList().ForEach(lines.Enqueue);

        DisplayNextLine();
    }

    public void StartThought(Dialogue dialogue)
    {
        if (thoughtCoroutine != null) StopCoroutine(thoughtCoroutine);
        thoughtCoroutine = StartCoroutine(DisplayThought(dialogue.lines));
    }

    IEnumerator DisplayThought(string[] lines)
    {
        foreach (string line in lines)
        {
            thoughtText.text = line;
            //fade in text
            thoughtAnim.SetBool("Visible", true);
            yield return new WaitForSeconds(3f);


            //fade out text
            thoughtAnim.SetBool("Visible", false);
            yield return new WaitForSeconds(1f);
        }

        thoughtText.text = "";
        thoughtCoroutine = null;
        thoughtText.alpha = 0;
    }

    public void DisplayNextLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        string line = lines.Dequeue();
        if (dialogueCoroutine != null) StopCoroutine(dialogueCoroutine);

        dialogueCoroutine = StartCoroutine(TypeLine(line));
    }

    IEnumerator TypeLine(string line)
    {
        dialogueLineText.text = "";

        foreach (char letter in line.ToCharArray())
        {
            dialogueLineText.text += letter;
            yield return null;
        }

        dialogueCoroutine = null;
    }

    private void EndDialogue()
    {
        dialogueAnim.SetBool("IsOpen", false);
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