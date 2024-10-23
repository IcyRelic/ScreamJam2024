using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendsHatItem : ThoughtTriggerItem
{


    protected override void Interact()
    {
        ProgressionManager.Instance.FriendsHat = true;
        base.Interact();
    }
}
