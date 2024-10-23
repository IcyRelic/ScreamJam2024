using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MapInteractable : Interactable
{

    /*** References ***/
    public String helpText;

    protected override void SetHelpText(string text)
    {
        textMeshPro.text =  $"{text}\n{helpText}";
    }
}
