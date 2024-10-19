using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    /*** References ***/
    private SpriteRenderer spriteRenderer;
    private Material defaultMaterial;
    [SerializeField] private Material outlineMaterial;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultMaterial = spriteRenderer.material;
    }

    public void Highlight()
    {
        spriteRenderer.material = outlineMaterial;
    }

    public void Unhighlight()
    {
        spriteRenderer.material = defaultMaterial;
    }


}
