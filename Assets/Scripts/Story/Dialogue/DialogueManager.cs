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

    [SerializeField] private Animator dialogueAnim;

    /** Variables **/
    private Queue<string> lines;


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

    public void DisplayNextLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        string line = lines.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeLine(line));
    }

    IEnumerator TypeLine(string line)
    {
        dialogueLineText.text = "";

        foreach (char letter in line.ToCharArray())
        {
            dialogueLineText.text += letter;
            yield return null;
        }
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