using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighterItem : ThoughtTriggerItem
{
    protected override void Interact()
    {
        ProgressionManager.Instance.Lighter = true;
        base.Interact();
    }
}
