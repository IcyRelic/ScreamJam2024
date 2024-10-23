using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerbItem : ThoughtTriggerItem
{
    protected override void Interact()
    {
        ProgressionManager.Instance.Herb = true;
        base.Interact();
    }

}
