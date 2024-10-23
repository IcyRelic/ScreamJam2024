using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    /*** References ***/
    protected SpriteRenderer spriteRenderer;
    protected Material defaultMaterial;
    protected new Collider2D collider2D;
    protected TMP_Text textMeshPro;


    /** Variables **/
    [SerializeField] private bool hasSprite = true;
    [SerializeField] private bool playSFX = false;
    [SerializeField] private int sfxID;

    public virtual void Awake()
    {
        if(hasSprite)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            defaultMaterial = spriteRenderer.material;
        }

        collider2D = GetComponent<Collider2D>();
        var canvas = GetComponentInChildren<Canvas>();
        textMeshPro = canvas.GetComponentInChildren<TMP_Text>();
    }

    public void Highlight()
    {
        if(!CanInteract()) return;
        if(hasSprite) spriteRenderer.material = GameManager.Instance.interactableHighlightMaterial;

        SetHelpText(PlayerController.Instance.GetControlSprite(PlayerController.Instance.Interact));
        textMeshPro.alpha = 1f;
    }

    protected virtual void SetHelpText(string text)
    {
        textMeshPro.text = text;
    }

    public void Unhighlight()
    {
        if(hasSprite) spriteRenderer.material = defaultMaterial;

        textMeshPro.text = "";
        textMeshPro.alpha = 0f;
    }
    
    public void AllowInteract(bool allow)
    {
        collider2D.enabled = allow;
    }

    public bool CanInteract()
    {
        return collider2D.enabled;
    }

    public void DestroyInteractable()
    {
        Debug.Log("Destroying Interactable");
        Destroy(gameObject);
    }

    protected abstract void Interact();

    public void CallInteract()
    {
        Interact();
        PlaySound();
        ProgressionManager.Instance.ProgressionCheck();
    }

    private void PlaySound()
    {
        if(playSFX) FindObjectOfType<AudioManager>().PlaySFX(sfxID);
    }
}
