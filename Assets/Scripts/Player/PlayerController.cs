using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    /*** References ***/
    private PlayerInput input;
    private new Camera camera;

    /*** Input Actions ***/
    public InputAction Movement { get; private set; }
    public InputAction Interact { get; private set; }
    public InputAction PrimaryAction { get; private set; }
    public InputAction SecondaryAction { get; private set; }
    public InputAction SkillCheck { get; private set; }

    /*** Input Values ***/
    public Vector2 MovementVector => Movement.ReadValue<Vector2>();
    public Vector2 MouseScreenPosition => Mouse.current.position.ReadValue();
    public Vector2 MousePosition => camera.ScreenToWorldPoint(new Vector3(MouseScreenPosition.x, MouseScreenPosition.y, 0));

    private void Awake()
    {        
        input = GetComponent<PlayerInput>();
        camera = Camera.main;

        Movement = input.actions["Movement"];
        Interact = input.actions["Interact"];
        PrimaryAction = input.actions["PrimaryAction"];
        SecondaryAction = input.actions["SecondaryAction"];
        SkillCheck = input.actions["SkillCheck"];


    }

    public bool CanUseInput()
    {
        return true;
    }

    public string GetControlSprite(InputAction action) 
    {
        string controlName = $"{input.currentControlScheme}_{GetBindingPath(action)}";
        return $"<sprite=\"{input.currentControlScheme}\" name=\"{controlName}\">";
    }

    private string GetBindingPath(InputAction action)
    {
        int i = action.GetBindingIndex(group: input.currentControlScheme);
        string path = action.bindings[i].path;
        path = Regex.Replace(path, @"(<Gamepad>|<Keyboard>|<Mouse>|/)", String.Empty);

        return path;
    }
}
