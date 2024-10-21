using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    /** References **/
    [SerializeField] private GameObject optionsMenu;

    public void NewGame() {

    }

    public void OpenOptions() 
    {
        optionsMenu.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsMenu.SetActive(false);
    }

    public void QuitGame() {
        Application.Quit();
    }

}
