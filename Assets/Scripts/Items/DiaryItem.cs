using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryItem : ThoughtTriggerItem
{

    protected override void Interact()
    {
        ProgressionManager.Instance.Diary = true;
        base.Interact();
    }

}
