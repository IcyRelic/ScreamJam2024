using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class Player : MonoBehaviour
{
    /*** References ***/
    private PlayerController controller;
    private Rigidbody2D rb;
    private Animator anim;
    private Light2D light;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private Transform worldSpawnPoint;
    

    
    /*** Values ***/
    public float movementSpeed = 2.5f;
    [SerializeField] [Range(0.1f, 1f)] private float interactableDistance = 1f;


    /*** Variables ***/
    private Interactable currentInteractable;
    private float lastInteractTime = 0f;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        light = GetComponentInChildren<Light2D>();

        controller.Interact.performed += ctx => Interact();

        lastInteractTime = Time.time;
    }

    private void Start()
    {
        Teleport(worldSpawnPoint);
    }

    private void Update()
    {
        GetInteractables();
        ProcessInput();

       
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactableDistance);
    }

    private void GetInteractables()
    {
        Collider2D c2d = Physics2D.OverlapCircle(transform.position, interactableDistance, interactableLayer);

        if(c2d == null)
        {
            if(currentInteractable != null)
            {
                currentInteractable.Unhighlight();
                currentInteractable = null;
            }
            return;
        }

        Interactable interactable = c2d.GetComponent<Interactable>();

        if(interactable == currentInteractable) return;
        if(currentInteractable != null) currentInteractable.Unhighlight();

        currentInteractable = interactable;
        currentInteractable.Highlight();        
    }
    private void ProcessInput()
    {
        if(!controller.CanUseInput()) return;
        Move(controller.MovementVector * movementSpeed);

       //if(controller.Interact.triggered) Interact();
    }

    private void Move(Vector2 direction)
    {
        rb.velocity = new Vector2(direction.x, direction.y);
        anim.SetBool("Walking", direction != Vector2.zero);

        if(direction == Vector2.zero) return;

        float dirX = controller.MovementVector.x > 0 ? 1 : 0;
        float dirY = controller.MovementVector.y > 0 ? 1 : 0;

        if(dirY == 1 && controller.MovementVector.x != 0) dirY = 0;
        //if(dirX == 1 && controller.MovementVector.y != 0) dirX = 0;

        float finalDir = dirX == 1 || dirY == 1 ? 1 : 0;

        anim.SetFloat("Direction", finalDir);
    }

    public void Teleport(Transform point)
    {
        rb.position = point.position;
    }

    public void AdjustLight(float intensity = 0.1f, float inner = 0.05f, float outer = 10f, float falloff = 1f)
    {
        
        light.intensity = intensity;
        light.pointLightInnerRadius = inner;
        light.pointLightOuterRadius = outer;
        light.falloffIntensity = falloff;
    }

    private void Interact()
    {
        if(currentInteractable == null || !CanInteract()) return;
        lastInteractTime = Time.time;
        currentInteractable.CallInteract();
        
    }

    private bool CanInteract() => Time.time - lastInteractTime > .3f;
}
