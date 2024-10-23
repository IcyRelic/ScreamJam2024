using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightItem : ThoughtTriggerItem
{

    protected override void Interact()
    {
        ProgressionManager.Instance.Flashlight = true;
        FindObjectOfType<Player>().AdjustLight(0.2f, 0.8f, 10f, 0.9f);
        base.Interact();        
    }


}
