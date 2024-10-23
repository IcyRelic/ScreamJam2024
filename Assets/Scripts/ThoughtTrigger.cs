using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtTrigger : MonoBehaviour
{
    [SerializeField] private Dialogue thought;
    [SerializeField] private float delay = 0f;

    private void Start()
    {
        Invoke("InvokeThought", delay);
        Destroy(this, 1f);
    }

    private void InvokeThought()
    {
        FindObjectOfType<DialogueManager>().StartThought(thought);
    }
}
