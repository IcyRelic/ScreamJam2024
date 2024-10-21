using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    /** References **/
    [SerializeField] private GameObject optionsMenu;

    public void ResumeGame() 
    {
        
    }

    public void OpenOptions() 
    {
        optionsMenu.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsMenu.SetActive(false);
    }

    public void ReturnToMainMenu() 
    {
       
    }

}
