using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballBatItem : ThoughtTriggerItem
{
    protected override void Interact()
    {
        ProgressionManager.Instance.BaseballBat = true;
        base.Interact();
    }
}
