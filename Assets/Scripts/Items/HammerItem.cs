using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerItem : ThoughtTriggerItem
{
    protected override void Interact()
    {
        //ProgressionManager.Instance.Hammer = true;
        base.Interact();
    }
}