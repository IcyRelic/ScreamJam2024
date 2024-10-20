using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    /*** References ***/
    private SpriteRenderer spriteRenderer;
    private Material defaultMaterial;
    [SerializeField] private Material outlineMaterial;
    [SerializeField] private TMP_Text textMeshPro;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultMaterial = spriteRenderer.material;
    }

    public void Highlight()
    {
        spriteRenderer.material = outlineMaterial;
        textMeshPro.text = PlayerController.Instance.GetControlSprite(PlayerController.Instance.Interact);
        textMeshPro.gameObject.SetActive(true);
    }

    public void Unhighlight()
    {
        spriteRenderer.material = defaultMaterial;
        textMeshPro.text = "";
        textMeshPro.gameObject.SetActive(true);
    }


}
