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
        Collider2D interactable = Physics2D.OverlapCircle(transform.position, interactableDistance, interactableLayer);

        if(interactable != null)
        {
            interactableUI.text = $"Interact {controller.GetControlSprite(controller.Interact)}";

            
        }
        else
        {
            interactableUI.text = "";
        }

        
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
