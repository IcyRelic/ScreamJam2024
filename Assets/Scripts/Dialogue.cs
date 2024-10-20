using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Scriptable Objects/Dialogue")]
public class Dialogue : ScriptableObject
{
    public DialogueType dialogueType;
    public DialogueLineType dialogueLineType;

    public string[] lines;

    public string GetRandomLine()
    {
        return lines[Random.Range(0, lines.Length)];
    }
}

public enum DialogueType
{
    Thought,
    Story
}

public enum DialogueLineType
{
    Random,
    Sequential
}
