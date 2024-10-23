using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable
{

    protected override void Interact()
    {
        Debug.Log("Interacting with item");
    }

}
