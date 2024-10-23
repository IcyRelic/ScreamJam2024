using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailsItem : ThoughtTriggerItem
{
    protected override void Interact()
    {
        ProgressionManager.Instance.Nails = true;
        base.Interact();
    }
}