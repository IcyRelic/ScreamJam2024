using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagItem : ConditionalThoughtTriggerItem
{
    protected override void Interact()
    {
        ProgressionManager.Instance.Rag = true;
        base.Interact();
    }

    protected override Dialogue GetThought()
    {
        if(ProgressionManager.Instance.Oil && ProgressionManager.Instance.BaseballBat)
        {
            return thoughts[0];
        }
        else if(ProgressionManager.Instance.Oil)
        {
            return thoughts[1];
        }
        else if(ProgressionManager.Instance.BaseballBat)
        {
            return thoughts[2];
        }
        else
        {
            return thoughts[3];
        }
    }

}
