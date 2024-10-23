using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerItem : ThoughtTriggerItem
{
    protected override void Interact()
    {
        ProgressionManager.Instance.Finger = true;
        base.Interact();
    }
}
