using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryPageItem : Interactable
{
    /** References **/
    [SerializeField] private Dialogue dialogue;

    /** Variables **/
    [SerializeField] [Range(1, 4)] private int pageNumber;
    
    protected override void Interact()
    {
        switch (pageNumber)
        {
            case 1:
                ProgressionManager.Instance.DiaryPage1 = true;
                break;
            case 2:
                ProgressionManager.Instance.DiaryPage2 = true;
                break;
            case 3:
                ProgressionManager.Instance.DiaryPage3 = true;
                break;
            case 4:
                ProgressionManager.Instance.DiaryPage4 = true;
                ProgressionManager.Instance.MagicWord = true;
                break;
        }

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        DestroyInteractable();
    }

}
