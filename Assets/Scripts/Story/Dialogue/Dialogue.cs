using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Scriptable Objects/Dialogue")]
public class Dialogue : ScriptableObject
{

    public string characterName;
    public Sprite characterSprite;
    [TextArea(3, 10)] public string[] lines;


}
