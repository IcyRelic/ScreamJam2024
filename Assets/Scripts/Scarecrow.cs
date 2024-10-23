using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Scarecrow : MapInteractable
{

    /** Variables **/
    [SerializeField] private static int scarecrowCount = 0;
    [SerializeField] private static int searchCount = 0;

    [SerializeField] private static float successChance = .3f;

    [SerializeField] private Dialogue successDialogue;
    [SerializeField] private Dialogue failureDialogue;

    private void Start()
    {
        scarecrowCount++;
    }

    protected override void Interact()
    {
        DestroyInteractable();
        if(Search())
        {
            Debug.Log("Success");
            FindObjectOfType<DialogueManager>().StartThought(successDialogue);
            ProgressionManager.Instance.Key = true;
            
        }
        else
        {
            Debug.Log("Failure");
            FindObjectOfType<DialogueManager>().StartThought(failureDialogue);
        }

        
    }

    private bool Search()
    {
        searchCount++;

        Debug.Log($"Search Count: {searchCount} Forced: {searchCount == scarecrowCount}");

        if(searchCount == scarecrowCount) return true;
        float val = Random.value;
        Debug.Log($"Searching {val}");
        return val < successChance;
    }
}
