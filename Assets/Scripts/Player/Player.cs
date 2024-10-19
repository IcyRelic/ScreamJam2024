using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    /*** References ***/
    private PlayerController controller;
    private Rigidbody2D rb;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private TMP_Text interactableUI;

    
    /*** Values ***/
    public float movementSpeed = 2.5f;
    [SerializeField] [Min(1)] private float interactableDistance = 1f;


    /*** Variables ***/
    private Interactable currentInteractable;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();

        controller.Interact.performed += Interact;
    }

    private void Update()
    {
        GetInteractables();
        ProcessInput();

       
    }

    private void GetInteractables()
    {
        Collider2D c2d = Physics2D.OverlapCircle(transform.position, interactableDistance, interactableLayer);

        // If there is no interactable, return
        if(c2d == null)
        {
            interactableUI.text = "";
            if(currentInteractable != null)
            {
                currentInteractable.Unhighlight();
                currentInteractable = null;
            }
            return;
        }

        interactableUI.text = $"Interact {controller.GetControlSprite(controller.Interact)}";

        // If the interactable is the same as the current interactable, return
        Interactable interactable = c2d.GetComponent<Interactable>();
        if(interactable == currentInteractable) return;

        // If the interactable is different from the current interactable, highlight the new interactable
        if(currentInteractable != null)
        {
            currentInteractable.Unhighlight();
        }

        currentInteractable = interactable;

        currentInteractable.Highlight();        
    }
    private void ProcessInput()
    {
        if(!controller.CanUseInput()) return;
        Move(controller.MovementVector * movementSpeed);
    }

    private void Move(Vector2 direction)
    {
        rb.velocity = new Vector2(direction.x, direction.y);
    }

    private void Interact(InputAction.CallbackContext context)
    {

    }
}
